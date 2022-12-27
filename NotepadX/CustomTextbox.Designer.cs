namespace NotepadX
{
    partial class CustomTextbox
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomTextbox));
            this.FastColoredTextBox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.DocumentMap = new FastColoredTextBoxNS.DocumentMap();
            this.Rule = new FastColoredTextBoxNS.Ruler();
            ((System.ComponentModel.ISupportInitialize)(this.FastColoredTextBox)).BeginInit();
            this.SuspendLayout();
            // 
            // FastColoredTextBox
            // 
            this.FastColoredTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FastColoredTextBox.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.FastColoredTextBox.AutoScrollMinSize = new System.Drawing.Size(31, 18);
            this.FastColoredTextBox.BackBrush = null;
            this.FastColoredTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FastColoredTextBox.CharHeight = 18;
            this.FastColoredTextBox.CharWidth = 10;
            this.FastColoredTextBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.FastColoredTextBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FastColoredTextBox.IsReplaceMode = false;
            this.FastColoredTextBox.Location = new System.Drawing.Point(0, 30);
            this.FastColoredTextBox.Name = "FastColoredTextBox";
            this.FastColoredTextBox.Paddings = new System.Windows.Forms.Padding(0);
            this.FastColoredTextBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.FastColoredTextBox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("FastColoredTextBox.ServiceColors")));
            this.FastColoredTextBox.Size = new System.Drawing.Size(697, 501);
            this.FastColoredTextBox.TabIndex = 0;
            this.FastColoredTextBox.Zoom = 100;
            // 
            // DocumentMap
            // 
            this.DocumentMap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DocumentMap.BackColor = System.Drawing.Color.White;
            this.DocumentMap.ForeColor = System.Drawing.Color.Maroon;
            this.DocumentMap.Location = new System.Drawing.Point(703, 30);
            this.DocumentMap.Name = "DocumentMap";
            this.DocumentMap.Size = new System.Drawing.Size(127, 501);
            this.DocumentMap.TabIndex = 1;
            this.DocumentMap.Target = this.FastColoredTextBox;
            this.DocumentMap.Text = "documentMap1";
            // 
            // Rule
            // 
            this.Rule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Rule.BackColor = System.Drawing.Color.White;
            this.Rule.BackColor2 = System.Drawing.Color.White;
            this.Rule.Location = new System.Drawing.Point(0, 0);
            this.Rule.MaximumSize = new System.Drawing.Size(1073741823, 24);
            this.Rule.MinimumSize = new System.Drawing.Size(0, 24);
            this.Rule.Name = "Rule";
            this.Rule.Size = new System.Drawing.Size(697, 24);
            this.Rule.TabIndex = 2;
            this.Rule.Target = this.FastColoredTextBox;
            this.Rule.TickColor = System.Drawing.Color.Black;
            // 
            // CustomTextbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.Rule);
            this.Controls.Add(this.DocumentMap);
            this.Controls.Add(this.FastColoredTextBox);
            this.Name = "CustomTextbox";
            this.Size = new System.Drawing.Size(830, 531);
            this.Load += new System.EventHandler(this.CustomTextbox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FastColoredTextBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public FastColoredTextBoxNS.FastColoredTextBox FastColoredTextBox;
        public FastColoredTextBoxNS.DocumentMap DocumentMap;
        public FastColoredTextBoxNS.Ruler Rule;
    }
}
