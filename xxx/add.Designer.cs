namespace xxx
{
    partial class add
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
            this.userControl31 = new xxx.UserControl3();
            this.SuspendLayout();
            // 
            // userControl31
            // 
            this.userControl31.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.userControl31.Location = new System.Drawing.Point(-79, 10);
            this.userControl31.Name = "userControl31";
            this.userControl31.Size = new System.Drawing.Size(913, 458);
            this.userControl31.TabIndex = 5;
            // 
            // add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.userControl31);
            this.Name = "add";
            this.Size = new System.Drawing.Size(754, 478);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControl3 userControl31;
    }
}
