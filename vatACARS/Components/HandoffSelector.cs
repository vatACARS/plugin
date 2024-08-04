using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;
using vatACARS.Util;
using vatsys;
using static vatACARS.Helpers.Transceiver;

namespace vatACARS.Components
{
    public partial class HandoffSelector : BaseForm
    {
        private static HttpClient client = new HttpClient();
        private static Logger logger = new Logger("HandoffSelector");
        private static StationInformation[] OnlineStations;
        private static Label SelectedDataAuthority;
        private static Label SelectedSector;
        private Station selectedStation;
        private Dictionary<string, Sector[]> StationSectors = new Dictionary<string, Sector[]>();

        public HandoffSelector()
        {
            InitializeComponent();
            selectedStation = DispatchWindow.SelectedStation;
            OnlineStations = VatACARSInterface.stationsOnline;

            FetchOnlineATSUs();

            StyleComponent();
        }

        private void btn_handoff_Click(object sender, EventArgs e)
        {
            try
            {
                string dataAuthority = SelectedDataAuthority.Tag == null ? "END SERVICE" : $"NEXT DATA AUTHORITY {((StationInformation)SelectedDataAuthority.Tag).Station_Code}";
                string sector = SelectedSector.Tag == null ? "MONITOR UNICOM 122.8" : $"CONTACT @{((Sector)SelectedSector.Tag).Callsign}@ @{(long.Parse(((Sector)SelectedSector.Tag).Frequency) / 1000000.0).ToString("0.0##")}@";
                string encodedMessage = $"{dataAuthority}\n{sector}";
                FormUrlEncodedContent req = HoppiesInterface.ConstructMessage(selectedStation.Callsign, "CPDLC", $"/data2/{SentMessages}//WU/{encodedMessage}");
                _ = HoppiesInterface.SendMessage(req);

                addSentCPDLCMessage(new SentCPDLCMessage()
                {
                    Station = selectedStation.Callsign,
                    MessageId = SentMessages,
                    ReplyMessageId = SentMessages
                });

                addCPDLCMessage(new CPDLCMessage()
                {
                    State = MessageState.Uplink,
                    Station = selectedStation.Callsign,
                    Content = encodedMessage.Replace("@", "").Replace("\n", ", "),
                    TimeReceived = DateTime.UtcNow,
                    MessageId = SentMessages,
                    ReplyMessageId = -1
                });

                addTelexMessage(new TelexMessage()
                {
                    State = MessageState.Finished,
                    Station = ((StationInformation)SelectedDataAuthority.Tag).Station_Code,
                    Content = $"HANDED {selectedStation.Callsign} TO YOU THIS IS AN AUTO MSG, REPLY NOT REQD.",
                    TimeReceived = DateTime.UtcNow
                });

                FormUrlEncodedContent hand = HoppiesInterface.ConstructMessage(((StationInformation)SelectedDataAuthority.Tag).Station_Code, "CPDLC", $"/data2/{SentMessages}//N/HANDED {selectedStation.Callsign} TO YOU THIS IS AN AUTO MSG, REPLY NOT REQD.");
                _ = HoppiesInterface.SendMessage(hand);
                btn_logoff_Click(sender, e);
                Close();
            }
            catch (Exception ex)
            {
                logger.Log($"Oops: {ex.ToString()}");
            }
        }

        private void btn_logoff_Click(object sender, EventArgs e)
        {
            FormUrlEncodedContent req = HoppiesInterface.ConstructMessage(selectedStation.Callsign, "CPDLC", $"/data2/{SentMessages}//N/LOGOFF");
            _ = HoppiesInterface.SendMessage(req);
            selectedStation.removeStation();
            Close();
        }

        private void clearDataAuthorities()
        {
            tbl_dataAuthorities.Controls.Clear();
            Label noneButton = new Label();
            noneButton.Text = "(NONE)";
            noneButton.Size = new Size(104, 30);
            noneButton.Font = MMI.eurofont_winsml;
            noneButton.TextAlign = ContentAlignment.MiddleCenter;
            noneButton.ForeColor = Colours.GetColour(Colours.Identities.CPDLCMessageBackground);
            noneButton.BackColor = Colours.GetColour(Colours.Identities.CPDLCUplink);
            noneButton.Margin = new Padding(3); // A bit of spacing
            noneButton.Parent = tbl_dataAuthorities;

            noneButton.MouseEnter += (sender, e) => noneButton.BackColor = Colours.GetColour(SelectedDataAuthority == noneButton ? Colours.Identities.CPDLCUplink : Colours.Identities.CPDLCDownlink);
            noneButton.MouseLeave += (sender, e) => noneButton.BackColor = Colours.GetColour(SelectedDataAuthority == noneButton ? Colours.Identities.CPDLCDownlink : Colours.Identities.CPDLCUplink);

            noneButton.MouseUp += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (SelectedDataAuthority == noneButton) return;
                    if (SelectedDataAuthority != null) SelectedDataAuthority.BackColor = Colours.GetColour(Colours.Identities.CPDLCUplink);
                    SelectedDataAuthority = noneButton;
                    noneButton.BackColor = Colours.GetColour(Colours.Identities.CPDLCUplink);

                    clearSectors(true);
                    // Add vatsys network stations
                    List<SectorsVolumes.Sector> sectors = (from s in SectorsVolumes.Sectors
                                                           where s.HandoffEligible
                                                           orderby Network.GetOnlineATCs.Any((NetworkATC a) => a.Callsign == s.Callsign) descending,
                                                           s.Name
                                                           select s).ToList();
                    foreach (SectorsVolumes.Sector sec in sectors)
                    {
                        Sector sector = new Sector()
                        {
                            Name = sec.Name,
                            Callsign = sec.Callsign,
                            Frequency = sec.Frequency.ToString()
                        };

                        Label sectorBtn = new Label();
                        sectorBtn.Text = $"{sector.Name} {(long.Parse(sector.Frequency) / 1000000.0).ToString("0.0##")}";
                        sectorBtn.Tag = sector;
                        sectorBtn.Size = new Size(130, 30);
                        sectorBtn.Font = MMI.eurofont_winsml;
                        sectorBtn.TextAlign = ContentAlignment.MiddleCenter;
                        sectorBtn.ForeColor = Colours.GetColour(Colours.Identities.CPDLCMessageBackground);
                        sectorBtn.BackColor = Colours.GetColour(Colours.Identities.CPDLCUplink);
                        sectorBtn.Margin = new Padding(3); // A bit of spacing
                        sectorBtn.Parent = tbl_sectors;

                        sectorBtn.MouseEnter += (sender2, e2) => sectorBtn.BackColor = Colours.GetColour(SelectedSector == sectorBtn ? Colours.Identities.CPDLCUplink : Colours.Identities.CPDLCDownlink);
                        sectorBtn.MouseLeave += (sender2, e2) => sectorBtn.BackColor = Colours.GetColour(SelectedSector == sectorBtn ? Colours.Identities.CPDLCDownlink : Colours.Identities.CPDLCUplink);

                        sectorBtn.MouseDown += (sender2, e2) =>
                        {
                            if (e2.Button == MouseButtons.Left)
                            {
                                if (SelectedSector == sectorBtn) return;
                                if (SelectedSector != null) SelectedSector.BackColor = Colours.GetColour(Colours.Identities.CPDLCUplink);
                                SelectedSector = sectorBtn;
                                sectorBtn.BackColor = Colours.GetColour(Colours.Identities.WindowButtonSelected);
                            }
                        };
                    }
                }
            };
        }

        private void clearSectors(bool addNoneButton = false)
        {
            tbl_sectors.Controls.Clear();

            if (addNoneButton)
            {
                Label noneButton = new Label();
                noneButton.Text = "(NONE)";
                noneButton.Tag = null;
                noneButton.Size = new Size(130, 30);
                noneButton.Font = MMI.eurofont_winsml;
                noneButton.TextAlign = ContentAlignment.MiddleCenter;
                noneButton.ForeColor = Colours.GetColour(Colours.Identities.CPDLCMessageBackground);
                noneButton.BackColor = Colours.GetColour(Colours.Identities.CPDLCUplink);
                noneButton.Margin = new Padding(3); // A bit of spacing
                noneButton.Parent = tbl_sectors;

                noneButton.MouseEnter += (sender, e) => noneButton.BackColor = Colours.GetColour(SelectedSector == noneButton ? Colours.Identities.CPDLCUplink : Colours.Identities.CPDLCDownlink);
                noneButton.MouseLeave += (sender, e) => noneButton.BackColor = Colours.GetColour(SelectedSector == noneButton ? Colours.Identities.CPDLCDownlink : Colours.Identities.CPDLCUplink);

                noneButton.MouseUp += (sender, e) =>
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        if (SelectedSector == noneButton) return;
                        if (SelectedSector != null) SelectedSector.BackColor = Colours.GetColour(Colours.Identities.CPDLCUplink);
                        SelectedSector = noneButton;
                        noneButton.BackColor = Colours.GetColour(Colours.Identities.WindowButtonSelected);
                    }
                };
            }
        }

        private void FetchOnlineATSUs()
        {
            clearDataAuthorities();
            clearSectors();

            if (OnlineStations == null) //Fix crash if not connected ;P
            {
                ErrorHandler.GetInstance().AddError("Not Connected To VatACARS");
            }
            else
            {
                foreach (StationInformation station in OnlineStations)
                {
                    Label btn = new Label();
                    btn.Text = station.Station_Code;
                    btn.Tag = station;
                    btn.Size = new Size(104, 30);
                    btn.Font = MMI.eurofont_winsml;
                    btn.TextAlign = ContentAlignment.MiddleCenter;
                    btn.ForeColor = Colours.GetColour(Colours.Identities.CPDLCMessageBackground);
                    btn.BackColor = Colours.GetColour(Colours.Identities.CPDLCUplink);
                    btn.Margin = new Padding(3); // A bit of spacing
                    btn.Parent = tbl_dataAuthorities;

                    btn.MouseEnter += (sender, e) => btn.BackColor = Colours.GetColour(SelectedDataAuthority == btn ? Colours.Identities.CPDLCUplink : Colours.Identities.CPDLCDownlink);
                    btn.MouseLeave += (sender, e) => btn.BackColor = Colours.GetColour(SelectedDataAuthority == btn ? Colours.Identities.CPDLCDownlink : Colours.Identities.CPDLCUplink);

                    btn.MouseDown += (sender, e) =>
                        {
                            if (e.Button == MouseButtons.Left)
                            {
                                if (SelectedDataAuthority == btn) return;
                                if (SelectedDataAuthority != null) SelectedDataAuthority.BackColor = Colours.GetColour(Colours.Identities.CPDLCUplink);
                                SelectedDataAuthority = btn;
                                btn.BackColor = Colours.GetColour(Colours.Identities.WindowButtonSelected);

                                clearSectors();

                                if (StationSectors.ContainsKey(station.Station_Code))
                                {
                                    foreach (Sector sector in StationSectors[station.Station_Code])
                                    {
                                        if (sector.Frequency == "0") continue;
                                        Label sectorBtn = new Label();
                                        sectorBtn.Text = $"{sector.Name} {(long.Parse(sector.Frequency) / 1000000.0).ToString("0.0##")}";
                                        sectorBtn.Tag = sector;
                                        sectorBtn.Size = new Size(130, 30);
                                        sectorBtn.Font = MMI.eurofont_winsml;
                                        sectorBtn.TextAlign = ContentAlignment.MiddleCenter;
                                        sectorBtn.ForeColor = Colours.GetColour(Colours.Identities.CPDLCMessageBackground);
                                        sectorBtn.BackColor = Colours.GetColour(Colours.Identities.CPDLCUplink);
                                        sectorBtn.Margin = new Padding(3); // A bit of spacing
                                        sectorBtn.Parent = tbl_sectors;

                                        sectorBtn.MouseEnter += (sender2, e2) => sectorBtn.BackColor = Colours.GetColour(SelectedSector == sectorBtn ? Colours.Identities.CPDLCUplink : Colours.Identities.CPDLCDownlink);
                                        sectorBtn.MouseLeave += (sender2, e2) => sectorBtn.BackColor = Colours.GetColour(SelectedSector == sectorBtn ? Colours.Identities.CPDLCDownlink : Colours.Identities.CPDLCUplink);

                                        sectorBtn.MouseDown += (sender2, e2) =>
                                        {
                                            if (e2.Button == MouseButtons.Left)
                                            {
                                                if (SelectedSector == sectorBtn) return;
                                                if (SelectedSector != null) SelectedSector.BackColor = Colours.GetColour(Colours.Identities.CPDLCUplink);
                                                SelectedSector = sectorBtn;
                                                sectorBtn.BackColor = Colours.GetColour(Colours.Identities.WindowButtonSelected);
                                            }
                                        };
                                    }
                                }
                            }
                        };

                    StationSectors.Add(station.Station_Code, JsonConvert.DeserializeObject<Sector[]>(station.Sectors));
                }
            }
        }

        private void HandoffSelector_ResizeBegin(object sender, EventArgs e)
        {
            tbl_dataAuthorities.SuspendLayout();
            tbl_sectors.SuspendLayout();
        }

        private void HandoffSelector_ResizeEnd(object sender, EventArgs e)
        {
            int columnWidth = 98;
            int columns = (int)(tbl_dataAuthorities.ClientRectangle.Width / columnWidth);
            tbl_dataAuthorities.ColumnCount = columns;

            int columnWidthSectors = 123;
            int columnsSectors = (int)(tbl_sectors.ClientRectangle.Width / columnWidthSectors);
            tbl_sectors.ColumnCount = columnsSectors;

            tbl_dataAuthorities.ResumeLayout();
            tbl_sectors.ResumeLayout();
            tbl_dataAuthorities.Invalidate();
            tbl_sectors.Invalidate();
        }

        private void HandoffSelector_Shown(object sender, EventArgs e)
        {
            this.Text = ($"Handoff {selectedStation.Callsign}");
        }

        private void StyleComponent()
        {
            Text = selectedStation.Callsign;
        }
    }
}