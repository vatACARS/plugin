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
            private bool disposed = false;

            public ACARSListViewItem(string text, int imageIndex, ListViewEx parentContainer) : base(new string[] { text }, imageIndex)
            {
                ContextMenu = new ContextMenuProp(parentContainer, this);
            }

            ~ACARSListViewItem()
            {
                Dispose(false);
            }

            public ContextMenuProp ContextMenu { get; private set; }

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

            internal class ContextMenuProp : IDisposable
            {
                public ContextMenuProp(ListViewEx parentContainer, ACARSListViewItem parent)
                {
                    ParentContainer = parentContainer;
                    ACARSListViewItem = parent;
                }

                public List<GenericButton> MenuButtons { get; set; } = new List<GenericButton>();
                public bool Open { get; private set; } = false;
                private ACARSListViewItem ACARSListViewItem { get; set; }
                private ListViewEx ParentContainer { get; set; }

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

                public void Dispose()
                {
                    foreach (var button in MenuButtons)
                    {
                        ParentContainer.Controls.Remove(button);
                        button.Dispose();
                    }
                    MenuButtons.Clear();
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
            }
        }
    }
}