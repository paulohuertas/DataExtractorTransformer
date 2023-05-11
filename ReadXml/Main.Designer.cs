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
            this.SuspendLayout();
            // 
            // txt_FilePath
            // 
            this.txt_FilePath.Location = new System.Drawing.Point(47, 68);
            this.txt_FilePath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_FilePath.Name = "txt_FilePath";
            this.txt_FilePath.Size = new System.Drawing.Size(438, 23);
            this.txt_FilePath.TabIndex = 0;
            // 
            // lb_FilePath
            // 
            this.lb_FilePath.AutoSize = true;
            this.lb_FilePath.Location = new System.Drawing.Point(47, 46);
            this.lb_FilePath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_FilePath.Name = "lb_FilePath";
            this.lb_FilePath.Size = new System.Drawing.Size(55, 15);
            this.lb_FilePath.TabIndex = 1;
            this.lb_FilePath.Text = "File Path";
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(499, 65);
            this.btn_Search.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(65, 26);
            this.btn_Search.TabIndex = 2;
            this.btn_Search.Text = "Search";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // btn_ParseFile
            // 
            this.btn_ParseFile.Location = new System.Drawing.Point(591, 65);
            this.btn_ParseFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_ParseFile.Name = "btn_ParseFile";
            this.btn_ParseFile.Size = new System.Drawing.Size(65, 26);
            this.btn_ParseFile.TabIndex = 3;
            this.btn_ParseFile.Text = "Parse";
            this.btn_ParseFile.UseVisualStyleBackColor = true;
            this.btn_ParseFile.Click += new System.EventHandler(this.btn_ParseFile_Click);
            // 
            // txt_Output
            // 
            this.txt_Output.Location = new System.Drawing.Point(51, 176);
            this.txt_Output.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_Output.Multiline = true;
            this.txt_Output.Name = "txt_Output";
            this.txt_Output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Output.Size = new System.Drawing.Size(608, 193);
            this.txt_Output.TabIndex = 0;
            // 
            // lbl_Output
            // 
            this.lbl_Output.AutoSize = true;
            this.lbl_Output.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Output.Location = new System.Drawing.Point(47, 141);
            this.lbl_Output.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Output.Name = "lbl_Output";
            this.lbl_Output.Size = new System.Drawing.Size(105, 20);
            this.lbl_Output.TabIndex = 4;
            this.lbl_Output.Text = "XML Output";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(803, 422);
            this.Controls.Add(this.lbl_Output);
            this.Controls.Add(this.btn_ParseFile);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.lb_FilePath);
            this.Controls.Add(this.txt_Output);
            this.Controls.Add(this.txt_FilePath);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
    }
}

