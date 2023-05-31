namespace ReadXml
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txt_FilePath = new System.Windows.Forms.TextBox();
            this.lb_FilePath = new System.Windows.Forms.Label();
            this.btn_Search = new System.Windows.Forms.Button();
            this.btn_ParseFile = new System.Windows.Forms.Button();
            this.txt_Output = new System.Windows.Forms.TextBox();
            this.lbl_Output = new System.Windows.Forms.Label();
            this.jurisdiction_cb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txt_FilePath
            // 
            this.txt_FilePath.Location = new System.Drawing.Point(44, 144);
            this.txt_FilePath.Margin = new System.Windows.Forms.Padding(2);
            this.txt_FilePath.Name = "txt_FilePath";
            this.txt_FilePath.Size = new System.Drawing.Size(548, 23);
            this.txt_FilePath.TabIndex = 0;
            // 
            // lb_FilePath
            // 
            this.lb_FilePath.AutoSize = true;
            this.lb_FilePath.Location = new System.Drawing.Point(41, 115);
            this.lb_FilePath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_FilePath.Name = "lb_FilePath";
            this.lb_FilePath.Size = new System.Drawing.Size(55, 15);
            this.lb_FilePath.TabIndex = 1;
            this.lb_FilePath.Text = "File Path";
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(620, 141);
            this.btn_Search.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(65, 26);
            this.btn_Search.TabIndex = 2;
            this.btn_Search.Text = "Search";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // btn_ParseFile
            // 
            this.btn_ParseFile.Location = new System.Drawing.Point(705, 141);
            this.btn_ParseFile.Margin = new System.Windows.Forms.Padding(2);
            this.btn_ParseFile.Name = "btn_ParseFile";
            this.btn_ParseFile.Size = new System.Drawing.Size(65, 26);
            this.btn_ParseFile.TabIndex = 3;
            this.btn_ParseFile.Text = "Parse";
            this.btn_ParseFile.UseVisualStyleBackColor = true;
            this.btn_ParseFile.Click += new System.EventHandler(this.btn_ParseFile_Click);
            // 
            // txt_Output
            // 
            this.txt_Output.Location = new System.Drawing.Point(47, 218);
            this.txt_Output.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Output.Multiline = true;
            this.txt_Output.Name = "txt_Output";
            this.txt_Output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Output.Size = new System.Drawing.Size(723, 193);
            this.txt_Output.TabIndex = 0;
            // 
            // lbl_Output
            // 
            this.lbl_Output.AutoSize = true;
            this.lbl_Output.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Output.Location = new System.Drawing.Point(43, 186);
            this.lbl_Output.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Output.Name = "lbl_Output";
            this.lbl_Output.Size = new System.Drawing.Size(105, 20);
            this.lbl_Output.TabIndex = 4;
            this.lbl_Output.Text = "XML Output";
            // 
            // jurisdiction_cb
            // 
            this.jurisdiction_cb.FormattingEnabled = true;
            this.jurisdiction_cb.Location = new System.Drawing.Point(223, 55);
            this.jurisdiction_cb.Name = "jurisdiction_cb";
            this.jurisdiction_cb.Size = new System.Drawing.Size(121, 23);
            this.jurisdiction_cb.TabIndex = 5;
            this.jurisdiction_cb.Text = "Jurisdiction Code";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Jurisdiction";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(402, -33);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 23);
            this.comboBox2.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(803, 422);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.jurisdiction_cb);
            this.Controls.Add(this.lbl_Output);
            this.Controls.Add(this.btn_ParseFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.lb_FilePath);
            this.Controls.Add(this.txt_Output);
            this.Controls.Add(this.txt_FilePath);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "CODE LIST TRANSFORMER";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_FilePath;
        private System.Windows.Forms.Label lb_FilePath;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Button btn_ParseFile;
        private System.Windows.Forms.TextBox txt_Output;
        private System.Windows.Forms.Label lbl_Output;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox jurisdiction_cb;
    }
}

