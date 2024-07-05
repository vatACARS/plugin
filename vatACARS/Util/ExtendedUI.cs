using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using vatsys;

namespace vatACARS.Util
{
    internal class ExtendedUI
    {
        internal class ACARSListViewItem : ListViewItem, IDisposable
        {
            public ContextMenuProp ContextMenu { get; private set; }
            private bool disposed = false;
            public ACARSListViewItem(string text, int imageIndex, ListViewEx parentContainer) : base(new string[] { text }, imageIndex) {
                ContextMenu = new ContextMenuProp(parentContainer, this);
            }

            // Implement IDisposable.
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected virtual void Dispose(bool disposing)
            {
                if (disposed) return;
                if (disposing) ContextMenu.Dispose();
                disposed = true;
            }

            ~ACARSListViewItem()
            {
                Dispose(false);
            }

            internal class ContextMenuProp : IDisposable
            {
                public bool Open { get; private set; } = false;
                public List<GenericButton> MenuButtons { get; set; } = new List<GenericButton>();
                private ListViewEx ParentContainer { get; set; }
                private ACARSListViewItem ACARSListViewItem { get; set; }

                public ContextMenuProp(ListViewEx parentContainer, ACARSListViewItem parent)
                {
                    ParentContainer = parentContainer;
                    ACARSListViewItem = parent;
                }

                public GenericButton CreateButton()
                {
                    GenericButton btn = new GenericButton();
                    btn.Visible = false;
                    btn.Font = MMI.eurofont_winsml;
                    btn.Size = new Size(btn.Size.Width, btn.Size.Height - 1);

                    MenuButtons.Add(btn);
                    ParentContainer.Controls.Add(btn);

                    return btn;
                }

                public void Show(bool enable)
                {
                    Point ctrlLoc = ACARSListViewItem.Bounds.Location;
                    for (int i = MenuButtons.Count; i > 0; i--)
                    {
                        GenericButton b = MenuButtons[i - 1];
                        b.Location = new Point(ctrlLoc.X + ACARSListViewItem.Bounds.Width + 52 - (b.Width * (i + 1)) - (4 * (i + 1)), ctrlLoc.Y);
                    }

                    foreach (GenericButton btn in MenuButtons)
                    {
                        btn.Visible = enable;
                    }
                    Open = enable;
                }

                public void Dispose()
                {
                    foreach (var button in MenuButtons)
                    {
                        ParentContainer.Controls.Remove(button);
                        button.Dispose();
                    }
                    MenuButtons.Clear();
                }
            }
        }
    }
}
