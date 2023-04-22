namespace ReadXml
{
    partial class Form1
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
            this.txt_FilePath = new System.Windows.Forms.TextBox();
            this.lb_FilePath = new System.Windows.Forms.Label();
            this.btn_Search = new System.Windows.Forms.Button();
            this.btn_ParseFile = new System.Windows.Forms.Button();
            this.txt_Output = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_FilePath
            // 
            this.txt_FilePath.Location = new System.Drawing.Point(55, 71);
            this.txt_FilePath.Name = "txt_FilePath";
            this.txt_FilePath.Size = new System.Drawing.Size(500, 22);
            this.txt_FilePath.TabIndex = 0;
            // 
            // lb_FilePath
            // 
            this.lb_FilePath.AutoSize = true;
            this.lb_FilePath.Location = new System.Drawing.Point(55, 49);
            this.lb_FilePath.Name = "lb_FilePath";
            this.lb_FilePath.Size = new System.Drawing.Size(63, 17);
            this.lb_FilePath.TabIndex = 1;
            this.lb_FilePath.Text = "File Path";
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(583, 69);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(75, 23);
            this.btn_Search.TabIndex = 2;
            this.btn_Search.Text = "Search";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // btn_ParseFile
            // 
            this.btn_ParseFile.Location = new System.Drawing.Point(676, 69);
            this.btn_ParseFile.Name = "btn_ParseFile";
            this.btn_ParseFile.Size = new System.Drawing.Size(75, 23);
            this.btn_ParseFile.TabIndex = 3;
            this.btn_ParseFile.Text = "Parse";
            this.btn_ParseFile.UseVisualStyleBackColor = true;
            this.btn_ParseFile.Click += new System.EventHandler(this.btn_ParseFile_Click);
            // 
            // txt_Output
            // 
            this.txt_Output.Location = new System.Drawing.Point(58, 188);
            this.txt_Output.Multiline = true;
            this.txt_Output.Name = "txt_Output";
            this.txt_Output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Output.Size = new System.Drawing.Size(693, 206);
            this.txt_Output.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 450);
            this.Controls.Add(this.btn_ParseFile);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.lb_FilePath);
            this.Controls.Add(this.txt_Output);
            this.Controls.Add(this.txt_FilePath);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_FilePath;
        private System.Windows.Forms.Label lb_FilePath;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Button btn_ParseFile;
        private System.Windows.Forms.TextBox txt_Output;
    }
}

