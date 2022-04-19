
namespace PuppeteerSharp_test
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ScreenShotPng = new System.Windows.Forms.PictureBox();
            this.textError = new System.Windows.Forms.TextBox();
            this.InputUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ScreenShotAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ScreenShotPng)).BeginInit();
            this.SuspendLayout();
            // 
            // ScreenShotPng
            // 
            this.ScreenShotPng.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScreenShotPng.Location = new System.Drawing.Point(12, 52);
            this.ScreenShotPng.Name = "ScreenShotPng";
            this.ScreenShotPng.Size = new System.Drawing.Size(743, 495);
            this.ScreenShotPng.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ScreenShotPng.TabIndex = 0;
            this.ScreenShotPng.TabStop = false;
            // 
            // textError
            // 
            this.textError.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textError.Location = new System.Drawing.Point(0, 553);
            this.textError.Name = "textError";
            this.textError.ReadOnly = true;
            this.textError.Size = new System.Drawing.Size(766, 21);
            this.textError.TabIndex = 1;
            // 
            // InputUrl
            // 
            this.InputUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputUrl.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.InputUrl.Location = new System.Drawing.Point(51, 17);
            this.InputUrl.Name = "InputUrl";
            this.InputUrl.Size = new System.Drawing.Size(614, 26);
            this.InputUrl.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Url";
            // 
            // ScreenShotAll
            // 
            this.ScreenShotAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ScreenShotAll.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ScreenShotAll.Location = new System.Drawing.Point(671, 14);
            this.ScreenShotAll.Name = "ScreenShotAll";
            this.ScreenShotAll.Size = new System.Drawing.Size(83, 29);
            this.ScreenShotAll.TabIndex = 6;
            this.ScreenShotAll.Text = "网页截图";
            this.ScreenShotAll.UseVisualStyleBackColor = true;
            this.ScreenShotAll.Click += new System.EventHandler(this.ScreenShotAll_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 574);
            this.Controls.Add(this.ScreenShotAll);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.InputUrl);
            this.Controls.Add(this.textError);
            this.Controls.Add(this.ScreenShotPng);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.ScreenShotPng)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ScreenShotPng;
        private System.Windows.Forms.TextBox textError;
        private System.Windows.Forms.TextBox InputUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ScreenShotAll;
    }
}

