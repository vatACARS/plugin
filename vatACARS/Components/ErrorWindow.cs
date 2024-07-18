using System;
using System.Linq;
using System.Windows.Forms;
using vatACARS.Util;
using vatsys;

namespace vatACARS.Components
{
    public partial class ErrorWindow : BaseForm
    {
        private static Logger logger = new Logger("ErrorWindow");
        private Timer colourTimeout;
        private ErrorHandler errorHandler;

        public ErrorWindow(ErrorHandler errorHandler)
        {
            this.errorHandler = errorHandler;
            InitializeComponent();
            StyleComponent();
            DisplayErrors();
            this.colourTimeout = new Timer();
            this.colourTimeout.Interval = 1000;
            this.colourTimeout.Tick += new EventHandler(this.colourTimeout_Tick);
            this.colourTimeout.Start();
        }

        public void DisplayErrors()
        {
            messagePanel.Controls.Clear();

            foreach (var error in errorHandler.Errors)
            {
                var label = CreateErrorLabel(error);
                messagePanel.Controls.Add(label);
            }

            if (errorHandler.Errors.Count == 0)
            {
                this.Close();
            }
        }

        public void StyleComponent()
        {
            insetPanel2.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
            messagePanel.BackColor = Colours.GetColour(Colours.Identities.WindowBackground);
        }

        public void UpdateErrors()
        {
            try
            {
                DisplayErrors();
            }
            catch (Exception ex)
            {
                logger.Log("Error in UpdateErrors: " + ex.Message);
            }
        }

        private void colourTimeout_Tick(object sender, EventArgs e)
        {
            foreach (Label label in this.messagePanel.Controls.OfType<Label>())
            {
                var errorId = (Guid)label.Tag;
                var errorInfo = errorHandler.Errors.FirstOrDefault(err => err.Id == errorId);
                if (errorInfo != null && (DateTime.UtcNow - errorInfo.Timestamp).TotalSeconds > 5.0)
                    label.ForeColor = Colours.GetColour(Colours.Identities.InteractiveText);
            }
        }

        private Label CreateErrorLabel(ErrorHandler.ErrorInfo error)
        {
            var label = new Label();
            label.Text = error.Message;
            label.AutoSize = true;
            label.Font = MMI.eurofont_winsml;
            label.ForeColor = Colours.GetColour(Colours.Identities.WindowWarning);
            label.Padding = new Padding(5);
            label.Tag = error.Id;

            label.MouseUp += (sender, e) =>
            {
                if (e.Button == MouseButtons.Middle)
                {
                    var errorId = (Guid)label.Tag;
                    errorHandler.RemoveError(errorId);
                    UpdateErrors();
                }
            };

            return label;
        }
    }
}