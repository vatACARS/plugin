using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
        }

        private void StyleComponent()
        {
            lvw_messages.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            scr_cpdlc.ForeColor = Colours.GetColour(Colours.Identities.WindowBackground);
            scr_cpdlc.BackColor = Colours.GetColour(Colours.Identities.WindowButtonSelected);
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
                ListViewItem item = new ListViewItem(message.TimeReceived.ToString("HHmm"));
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

        private void lvw_messages_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            Font font = MMI.eurofont_winsml;
            SolidBrush bg = new SolidBrush(e.Item.BackColor);
            SolidBrush fg = new SolidBrush(e.Item.ForeColor);
            e.Graphics.FillRectangle(bg, e.Bounds);
            int n = 0;
            foreach(ListViewItem.ListViewSubItem subItem in e.Item.SubItems)
            {
                StringFormat format = new StringFormat();
                format.LineAlignment = StringAlignment.Center;
                format.Alignment = StringAlignment.Near;
                int offset = lvw_messages.ClientSize.Width - n;
                SizeF strSpace = e.Graphics.MeasureString(subItem.Text, font);
                if (strSpace.Width > (float)offset)
                {
                    int place = (int)Math.Floor((float)offset / (strSpace.Width / (float)subItem.Text.Length));
                    if (place > 0) e.Graphics.DrawString(subItem.Text.Substring(0, place) + "...", font, fg, subItem.Bounds, format);
                }
                else e.Graphics.DrawString(subItem.Text, font, fg, subItem.Bounds, format);
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
                if(e.Button == MouseButtons.Left)
                {
                    CPDLCMessage msg = (CPDLCMessage)selected.Tag;
                    if(msg.State == 0)
                    {
                        SelectedMessage = msg;
                        EditorWindow window = new EditorWindow();
                        window.Show();
                    }
                    lvw_messages.Invalidate();
                }
            }
        }
    }
}
