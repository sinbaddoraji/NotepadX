using System.ComponentModel;
using System.IO;
using System.Text.Json;

namespace NotepadX
{
    public partial class Form1 : Form
    {
        public FileTab? CurrentFileTab => tabControl.SelectedTab as FileTab ?? null;
       
        public FontDialog FontDialog { get; set; }
        public Form1()
        {
            InitializeComponent();
            InitalizeTheme();
            NewTab();
            timer1.Start();
        }

        string themeFile = "Theme.json";

        public void InitalizeTheme()
        {
            

            if (File.Exists(themeFile))
            {
                string themeString = File.ReadAllText(themeFile);
                Theme.Instance = JsonSerializer.Deserialize<Theme>(themeString);
            }
            else
            {
                Theme.Instance = new Theme();
                Theme.Instance.TextboxBackgroundColorHex = Color.White.Name;
                Theme.Instance.TextboxForegroundColorHex = Color.Black.Name;
                Theme.Instance.BackgroundColourHex = Color.White.Name;
                Theme.Instance.MenuBackgroundColorHex = Color.White.Name;
                Theme.Instance.MenuForegroundColorHex = Color.Black.Name;

               SaveThemeSettings();
            }

           
            this.BackColor = Color.FromName(Theme.Instance.BackgroundColourHex);


            this.statusStrip1.BackColor = this.menuStrip1.BackColor = Color.FromName(Theme.Instance.MenuBackgroundColorHex);
            this.ForeColor = this.menuStrip1.ForeColor = this.statusStrip1.ForeColor = Color.FromName(Theme.Instance.MenuForegroundColorHex);

            FontDialog = FontDialog ?? new FontDialog();
            FontDialog.Font = Font;

            Theme.Instance.PropertyChanged += NewTabOnPropertyChanged;

        }

        private void SaveThemeSettings()
        {
            var jsonDocument = System.Text.Json.JsonSerializer.Serialize(Theme.Instance);
            File.WriteAllText(themeFile, jsonDocument);
        }

        private void NewTab()
        {
            var newTab = new FileTab();
            tabControl.Controls.Add(newTab);
            EnforceTheme();
        }

        private void NewTabOnPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            EnforceTheme();
        }

        private void EnforceTheme()
        {
            foreach (FileTab tab in tabControl.TabPages)
            {
                tab.SetFont(
                    FontFamily.Families
                        .FirstOrDefault(x => x.Name == FontDialog.Font.FontFamily.Name) ?? FontFamily.GenericSansSerif,
                    Theme.Instance.FontStyle,
                    Theme.Instance.FontSize);

                tab.BackColor = Color.FromName(Theme.Instance.TextboxBackgroundColorHex);
                tab.ForeColor = Color.FromName(Theme.Instance.TextboxForegroundColorHex);
                

                tab.CustomTextBox.BackColor = tab.BackColor;
                tab.CustomTextBox.ForeColor = tab.ForeColor;
            }
        }


        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewTab();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentFileTab?.Open();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            Text = CurrentFileTab?.OpenedFile;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentFileTab?.Save();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentFileTab?.SaveAs();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentFileTab?.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentFileTab?.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentFileTab?.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentFileTab?.SelectAll();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentFileTab?.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentFileTab?.Redo();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FontDialog.ShowDialog() == DialogResult.OK)
            {
                Theme.Instance.FontSize = FontDialog.Font.Size;
                Theme.Instance.FontStyle = FontDialog.Font.Style;
                Theme.Instance.FontFamily = FontDialog.Font.FontFamily.Name;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveThemeSettings();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = CurrentFileTab.CursorLocation;
        }
    }
}