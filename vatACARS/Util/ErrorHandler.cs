﻿using System;
using System.Collections.Generic;
using System.Threading;
using vatACARS.Components;

namespace vatACARS.Util
{
    public class ErrorHandler
    {
        private static ErrorHandler instance;
        private Logger logger = new Logger("ErrorHandler");
        public List<ErrorInfo> Errors { get; private set; }
        private ErrorWindow errorWindow;
        private SynchronizationContext uiContext;
        private ErrorHandler()
        {
            Errors = new List<ErrorInfo>();
            uiContext = SynchronizationContext.Current;
        }
        public static ErrorHandler GetInstance()
        {
            if (instance == null)
            {
                instance = new ErrorHandler();
            }
            return instance;
        }

        public void AddError(string message)
        {
            try
            {
                var error = new ErrorInfo { Id = Guid.NewGuid(), Message = message, Timestamp = DateTime.UtcNow };
                Errors.Add(error);
                logger.Log("Error Occurred: " + message);
                ShowErrorWindow();
                AudioInterface.playSound("error");
            }
            catch (Exception ex)
            {
                logger.Log("Error adding error: " + ex.Message);
            }
        }

        public void RemoveError(Guid errorId)
        {
            Errors.RemoveAll(e => e.Id == errorId);
            UpdateErrorWindow();
        }

        private void ShowErrorWindow()
        {
            uiContext.Post(state =>
            {
                if (errorWindow == null || errorWindow.IsDisposed)
                {
                    errorWindow = new ErrorWindow(this);
                    errorWindow.FormClosed += (s, e) => errorWindow = null;
                    errorWindow.Show();
                }
                else
                {
                    errorWindow.UpdateErrors();
                }
            }, null);
        }

        private void UpdateErrorWindow()
        {
            uiContext.Post(state =>
            {
                errorWindow?.UpdateErrors();
            }, null);
        }

        public class ErrorInfo
        {
            public Guid Id { get; set; }
            public string Message { get; set; }
            public DateTime Timestamp { get; set; }
        }
    }
}