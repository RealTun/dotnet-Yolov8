namespace WinformApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_detect = new Button();
            SuspendLayout();
            // 
            // btn_detect
            // 
            btn_detect.Location = new Point(427, 253);
            btn_detect.Name = "btn_detect";
            btn_detect.Size = new Size(94, 29);
            btn_detect.TabIndex = 0;
            btn_detect.Text = "detect";
            btn_detect.UseVisualStyleBackColor = true;
            btn_detect.Click += btn_detect_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(960, 555);
            Controls.Add(btn_detect);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_detect;
    }
}
