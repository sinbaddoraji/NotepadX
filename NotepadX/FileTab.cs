using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FastColoredTextBoxNS;
using Timer = System.Windows.Forms.Timer;

namespace NotepadX
{
    public class FileTab : TabPage, INotifyPropertyChanged
    {
        private string _openedFile;
        public string OpenedFile
        {
            get
            {
                return _openedFile;
            }
            set
            {
                _openedFile = value;
                this.Text = _openedFile;

                OnPropertyChanged();
            }
        }
        public CustomTextbox CustomTextBox { get; set; } = new CustomTextbox();

        public FastColoredTextBox TextBox => CustomTextBox.FastColoredTextBox;

        private OpenFileDialog openFileDialog = new OpenFileDialog();

        private SaveFileDialog saveFileDialog = new SaveFileDialog();

        private Timer cursorTimer = new Timer();

        private string _cursorLocation;
        public string CursorLocation
        {
            get => _cursorLocation;
            set
            {
                _cursorLocation = value;
                OnPropertyChanged();
            }
        }
       
        public FileTab()
        {

            this.Controls.Add(CustomTextBox);
            CustomTextBox.Dock = DockStyle.Fill;
            OpenedFile = "Untitled";

            cursorTimer.Start();
            cursorTimer.Tick += CursorTimer_Tick;
            


            ToolStripMenuItem cutToolStripMenuItem = new ToolStripMenuItem("Cut");
            cutToolStripMenuItem.Click += delegate { Cut(); };

            ToolStripMenuItem copyStripMenuItemToolStripMenuItem = new ToolStripMenuItem("Copy");
            cutToolStripMenuItem.Click += delegate { Cut(); };

            ToolStripMenuItem pasteToolStripMenuItem = new ToolStripMenuItem("Paste");
            pasteToolStripMenuItem.Click += delegate { Paste(); };

            ToolStripMenuItem selectAllToolStripMenuItem = new ToolStripMenuItem("Select All");
            selectAllToolStripMenuItem.Click += delegate { SelectAll(); };

            ToolStripMenuItem undoToolStripMenuItem = new ToolStripMenuItem("Undo");
            undoToolStripMenuItem.Click += delegate { Undo(); };

            ToolStripMenuItem redoToolStripMenuItem = new ToolStripMenuItem("Redo");
            redoToolStripMenuItem.Click += delegate { Redo(); };

            TextBox.ContextMenuStrip = new ContextMenuStrip()
            {
                Items =
                {
                    undoToolStripMenuItem, redoToolStripMenuItem,
                    new ToolStripSeparator(),

                    cutToolStripMenuItem, copyStripMenuItemToolStripMenuItem,
                    pasteToolStripMenuItem, selectAllToolStripMenuItem
                }
            };

        }

        private void CursorTimer_Tick(object? sender, EventArgs e)
        {
            int line = TextBox.Selection.Start.iLine;
            int column = TextBox.Selection.Start.iChar;

            CursorLocation = $"Ln {line + 1}, Col {column}";
        }

        public void Open()
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                OpenedFile = openFileDialog.FileName;
                TextBox.OpenFile(OpenedFile);
            }
        }

        public void Save()
        {
            TextBox.SaveToFile(OpenedFile, Encoding.Default);
        }

        public void SaveAs()
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                OpenedFile = saveFileDialog.FileName;
                Save();
            }
        }

        public void Cut()
        {
            TextBox.Cut();
        }

        public void Copy()
        {
            TextBox.Copy();
        }

        public void Paste()
        {
            TextBox.Paste();
        }

        public void SelectAll()
        {
            TextBox.SelectAll();
        }

        public void Undo()
        {
            TextBox.Undo();
        }

        public void Redo()
        {
            TextBox.Redo();
        }

        public void SetFont(FontFamily fontFamily, FontStyle fontStyle, float fontSize)
        {
            TextBox.Font = new Font(
                fontFamily,
                fontSize, fontStyle
            );
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
}
