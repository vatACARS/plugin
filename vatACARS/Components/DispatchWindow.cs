using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Timers;
using System.Windows.Forms;
using vatACARS.Helpers;
using vatACARS.Util;
using vatsys;

namespace vatACARS.Components
{
    public partial class DispatchWindow : BaseForm
    {
        private static Logger logger = new Logger("DispatchWindow");
        private List<CPDLCMessage> messages = new List<CPDLCMessage>();
        private static System.Timers.Timer timer;
        private static ImageList il;
        public static CPDLCMessage SelectedMessage;

        public DispatchWindow()
        {
            InitializeComponent();
            StyleComponent();

            timer = new System.Timers.Timer();
            timer.Elapsed += PollTimer;
            timer.AutoReset = true; // Keep the timer running
            timer.Interval = 10_000;
            timer.Enabled = true;

            UpdateMessages();
            AddStation("QFA100");
            AddStation("JST100");
            AddStation("VOZ100");
            AddStation("BNZ100");
            AddStation("GIA100");
        }

        private void StyleComponent()
        {
            lvw_messages.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            scr_messages.ForeColor = Colours.GetColour(Colours.Identities.WindowBackground);
            scr_messages.BackColor = Colours.GetColour(Colours.Identities.WindowButtonSelected);
            scr_connections.ForeColor = Colours.GetColour(Colours.Identities.WindowBackground);
            scr_connections.BackColor = Colours.GetColour(Colours.Identities.WindowButtonSelected);

            il = new ImageList();
            il.Images.Add(Properties.Resources.RXIcon);
            il.Images.Add(Properties.Resources.TXIcon);
            il.Images.Add(Properties.Resources.DeferIcon);

            lvw_messages.SmallImageList = il;
        }

        private void PollTimer(object sender, ElapsedEventArgs e)
        {
            UpdateMessages();
        }

        private void UpdateMessages()
        {
            try
            {
                var tMsgs = Tranceiver.getAllCPDLCMessages().ToList();
                //if (tMsgs == messages) return;

                messages = tMsgs;
                lvw_messages.Items.Clear();
                foreach (var message in messages.ToArray())
                {
                    AddMessage(message);
                }

                AddMessage(new CPDLCMessage()
                {
                    State = 0,
                    Station = "QFA100",
                    Text = "REQUEST WEATHER DEVIATION UP TO 5NM LEFT OF ROUTE ",
                    TimeReceived = new DateTime()
                });

                AddMessage(new CPDLCMessage()
                {
                    State = 1,
                    Station = "QFA100",
                    Text = "(UPLINK) ",
                    TimeReceived = new DateTime()
                });

                AddMessage(new CPDLCMessage()
                {
                    State = 2,
                    Station = "QFA100",
                    Text = "(ACK) ",
                    TimeReceived = new DateTime()
                });

                lvw_messages.Invalidate();
            }
            catch (Exception ex)
            {
                logger.Log($"Something went wrong:\n{ex.ToString()}");
            }
        }

        public void AddMessage(CPDLCMessage message)
        {
            try
            {
                messages.Add(message);
                ListViewItem item = new ListViewItem(message.TimeReceived.ToString("HH:mm"), message.State);
                item.SubItems.Add($"{message.Station}: {message.Text}");
                item.Font = MMI.eurofont_winsml;
                item.Tag = message;
                if (message.State == 0)
                {
                    item.BackColor = Colours.GetColour(Colours.Identities.CPDLCDownlink);
                    item.ForeColor = Colours.GetColour(Colours.Identities.CPDLCMessageBackground);
                }
                else if (message.State == 1)
                {
                    item.BackColor = Colours.GetColour(Colours.Identities.CPDLCUplink);
                    item.ForeColor = Colours.GetColour(Colours.Identities.CPDLCMessageBackground);
                }
                else if (message.State == 2)
                {
                    item.BackColor = Colours.GetColour(Colours.Identities.CPDLCMessageBackground);
                    item.ForeColor = Colours.GetColour(Colours.Identities.CPDLCFreetext);
                }
                else
                {
                    item.BackColor = Colours.GetColour(Colours.Identities.CPDLCFreetext);
                    item.ForeColor = Colours.GetColour(Colours.Identities.CPDLCMessageBackground);
                }
                lvw_messages.Items.Add(item);
            } catch(Exception ex)
            {
                logger.Log($"Something went wrong:\n{ex.ToString()}");
            }
        }

        private void AddStation(string callsign)
        {
            Label callsignLabel = new Label();
            callsignLabel.Text = callsign;
            callsignLabel.TextAlign = ContentAlignment.MiddleCenter;
            callsignLabel.ForeColor = Colours.GetColour(Colours.Identities.CPDLCMessageBackground);
            callsignLabel.BackColor = Colours.GetColour(Colours.Identities.CPDLCUplink);
            callsignLabel.Margin = new Padding(3); // A bit of spacing

            callsignLabel.MouseEnter += (sender, e) => callsignLabel.BackColor = Colours.GetColour(Colours.Identities.CPDLCDownlink);
            callsignLabel.MouseLeave += (sender, e) => callsignLabel.BackColor = Colours.GetColour(Colours.Identities.CPDLCUplink);

            callsignLabel.MouseDown += (sender, e) =>
            {
                if(e.Button == MouseButtons.Left)
                {
                    SelectedMessage = new CPDLCMessage()
                    {
                        State = 0,
                        Station = callsignLabel.Text,
                        Text = "(no message received)",
                        TimeReceived = DateTime.Now
                    };

                    EditorWindow window = new EditorWindow();
                    window.Show(Form.ActiveForm);
                } else
                {
                    // Confirm logout
                }
            };

            tbl_connected.Controls.Add(callsignLabel);
        }

        private void lvw_messages_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            Font font = MMI.eurofont_winsml;
            SolidBrush bg = new SolidBrush(e.Item.BackColor);
            SolidBrush fg = new SolidBrush(e.Item.ForeColor);
            e.Graphics.FillRectangle(bg, e.Item.Bounds);
            int n = 0;
            foreach(ListViewItem.ListViewSubItem subItem in e.Item.SubItems)
            {
                StringFormat format = new StringFormat();
                format.LineAlignment = StringAlignment.Center;
                format.Alignment = StringAlignment.Near;
                int offset = lvw_messages.Columns[n].Width - (n == 0 ? 0 : (int)e.Graphics.MeasureString("......", font).Width);
                SizeF strSpace = e.Graphics.MeasureString(subItem.Text, font);
                if (strSpace.Width > (float)offset)
                {
                    int place = (int)Math.Floor((float)offset / (strSpace.Width / (float)subItem.Text.Length));
                    if (place > 0) e.Graphics.DrawString(subItem.Text.Substring(0, place) + "...", font, fg, subItem.Bounds, format);
                }
                else
                {
                    e.Graphics.DrawString(subItem.Text, font, fg, n == 0 ? new Rectangle(subItem.Bounds.X + 2, subItem.Bounds.Y, subItem.Bounds.Width, subItem.Bounds.Height) : subItem.Bounds, format);
                    if (n == 0 && e.Item.ImageIndex != -1) e.Graphics.DrawImage(il.Images[e.Item.ImageIndex], e.Bounds.Left + 55, e.Bounds.Top + ((e.Bounds.Height - il.Images[e.Item.ImageIndex].Height) / 2) - 1);
                }
                n++;
            }
        }

        private void lvw_messages_MouseUp(object sender, MouseEventArgs e)
        {
            lvw_messages.SelectedItems.Clear();
            ListViewItem selected = null;
            foreach(ListViewItem item in lvw_messages.Items)
            {
                if(item.Bounds.Contains(e.Location))
                {
                    item.Selected = true;
                    selected = item;
                    break;
                }
            }

            if(selected != null)
            {
                CPDLCMessage msg = (CPDLCMessage)selected.Tag;

                if (e.Button == MouseButtons.Left)
                {
                    if(msg.State == 0 || msg.State == 2)
                    {
                        SelectedMessage = msg;
                        EditorWindow window = new EditorWindow();
                        window.Show(Form.ActiveForm);
                    }
                    lvw_messages.Invalidate();
                } else if(e.Button == MouseButtons.Right)
                {
                    if(msg.State == 0)
                    {
                        msg.SetCPDLCMessageState(2);
                        lvw_messages.Invalidate();
                    }
                }
            }
        }

        private void tbl_connected_MouseDown(object sender, MouseEventArgs e)
        {
            
        }
    }
}
