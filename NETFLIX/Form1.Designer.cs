namespace NETFLIX
{
    partial class MovieForm
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
            this.exitButton = new System.Windows.Forms.Button();
            this.searchBar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MainPanal = new System.Windows.Forms.Panel();
            this.searchPanal = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Button();
            this.categoryBox = new System.Windows.Forms.ComboBox();
            this.MainPanal.SuspendLayout();
            this.SuspendLayout();
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.Black;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.ForeColor = System.Drawing.Color.Red;
            this.exitButton.Location = new System.Drawing.Point(1510, 9);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(25, 25);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "X";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // searchBar
            // 
            this.searchBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchBar.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F);
            this.searchBar.ForeColor = System.Drawing.Color.Red;
            this.searchBar.Location = new System.Drawing.Point(21, 62);
            this.searchBar.Name = "searchBar";
            this.searchBar.Size = new System.Drawing.Size(930, 25);
            this.searchBar.TabIndex = 4;
            this.searchBar.Text = "Search";
            this.searchBar.TextChanged += new System.EventHandler(this.searchBar_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(321, 50);
            this.label1.TabIndex = 5;
            this.label1.Text = "MOVIE LIBRARY";
            // 
            // MainPanal
            // 
            this.MainPanal.Controls.Add(this.searchPanal);
            this.MainPanal.Location = new System.Drawing.Point(21, 93);
            this.MainPanal.Name = "MainPanal";
            this.MainPanal.Size = new System.Drawing.Size(1212, 615);
            this.MainPanal.TabIndex = 6;
            // 
            // searchPanal
            // 
            this.searchPanal.Location = new System.Drawing.Point(0, 3);
            this.searchPanal.Name = "searchPanal";
            this.searchPanal.Size = new System.Drawing.Size(1212, 615);
            this.searchPanal.TabIndex = 7;
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.Black;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.ForeColor = System.Drawing.Color.Red;
            this.closeButton.Location = new System.Drawing.Point(1243, 9);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(25, 25);
            this.closeButton.TabIndex = 5;
            this.closeButton.Text = "X";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // categoryBox
            // 
            this.categoryBox.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F);
            this.categoryBox.ForeColor = System.Drawing.Color.Red;
            this.categoryBox.FormattingEnabled = true;
            this.categoryBox.Location = new System.Drawing.Point(958, 62);
            this.categoryBox.Name = "categoryBox";
            this.categoryBox.Size = new System.Drawing.Size(275, 27);
            this.categoryBox.TabIndex = 8;
            this.categoryBox.SelectedIndexChanged += new System.EventHandler(this.categoryBox_SelectedIndexChanged);
            // 
            // MovieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.categoryBox);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.searchBar);
            this.Controls.Add(this.MainPanal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exitButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MovieForm";
            this.Text = "MoviesForm";
            this.Load += new System.EventHandler(this.MovieForm_Load);
            this.MainPanal.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.TextBox searchBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel MainPanal;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Panel searchPanal;
        private System.Windows.Forms.ComboBox categoryBox;
    }
}

