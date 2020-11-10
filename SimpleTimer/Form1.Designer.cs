namespace SimpleTimer
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1_Date = new System.Windows.Forms.Label();
            this.button1_start = new System.Windows.Forms.Button();
            this.button2_stop = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label1_MainTimer = new System.Windows.Forms.Label();
            this.button1_Reset = new System.Windows.Forms.Button();
            this.button1_HOUR = new System.Windows.Forms.Button();
            this.button2_MIN = new System.Windows.Forms.Button();
            this.button3_SEC = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1_Date
            // 
            this.label1_Date.AutoSize = true;
            this.label1_Date.Location = new System.Drawing.Point(27, 126);
            this.label1_Date.Name = "label1_Date";
            this.label1_Date.Size = new System.Drawing.Size(35, 12);
            this.label1_Date.TabIndex = 0;
            this.label1_Date.Text = "label1";
            // 
            // button1_start
            // 
            this.button1_start.Location = new System.Drawing.Point(29, 153);
            this.button1_start.Name = "button1_start";
            this.button1_start.Size = new System.Drawing.Size(157, 52);
            this.button1_start.TabIndex = 2;
            this.button1_start.Text = "START";
            this.button1_start.UseVisualStyleBackColor = true;
            this.button1_start.Click += new System.EventHandler(this.button1_start_Click);
            // 
            // button2_stop
            // 
            this.button2_stop.Location = new System.Drawing.Point(225, 153);
            this.button2_stop.Name = "button2_stop";
            this.button2_stop.Size = new System.Drawing.Size(157, 52);
            this.button2_stop.TabIndex = 2;
            this.button2_stop.Text = "STOP";
            this.button2_stop.UseVisualStyleBackColor = true;
            this.button2_stop.Click += new System.EventHandler(this.button2_stop_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 10;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label1_MainTimer
            // 
            this.label1_MainTimer.AutoSize = true;
            this.label1_MainTimer.Font = new System.Drawing.Font("MS UI Gothic", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1_MainTimer.Location = new System.Drawing.Point(12, 9);
            this.label1_MainTimer.Name = "label1_MainTimer";
            this.label1_MainTimer.Size = new System.Drawing.Size(370, 97);
            this.label1_MainTimer.TabIndex = 3;
            this.label1_MainTimer.Text = "00:00:00";
            this.label1_MainTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1_Reset
            // 
            this.button1_Reset.Location = new System.Drawing.Point(167, 211);
            this.button1_Reset.Name = "button1_Reset";
            this.button1_Reset.Size = new System.Drawing.Size(75, 23);
            this.button1_Reset.TabIndex = 2;
            this.button1_Reset.Text = "RESET";
            this.button1_Reset.UseVisualStyleBackColor = true;
            this.button1_Reset.Click += new System.EventHandler(this.button1_Reset_Click);
            // 
            // button1_HOUR
            // 
            this.button1_HOUR.Location = new System.Drawing.Point(29, 246);
            this.button1_HOUR.Name = "button1_HOUR";
            this.button1_HOUR.Size = new System.Drawing.Size(75, 23);
            this.button1_HOUR.TabIndex = 4;
            this.button1_HOUR.Text = "HOUR";
            this.button1_HOUR.UseVisualStyleBackColor = true;
            this.button1_HOUR.Click += new System.EventHandler(this.button1_HOUR_Click);
            // 
            // button2_MIN
            // 
            this.button2_MIN.Location = new System.Drawing.Point(110, 246);
            this.button2_MIN.Name = "button2_MIN";
            this.button2_MIN.Size = new System.Drawing.Size(75, 23);
            this.button2_MIN.TabIndex = 4;
            this.button2_MIN.Text = "MIN";
            this.button2_MIN.UseVisualStyleBackColor = true;
            this.button2_MIN.Click += new System.EventHandler(this.button1_HOUR_Click);
            // 
            // button3_SEC
            // 
            this.button3_SEC.Location = new System.Drawing.Point(191, 246);
            this.button3_SEC.Name = "button3_SEC";
            this.button3_SEC.Size = new System.Drawing.Size(75, 23);
            this.button3_SEC.TabIndex = 4;
            this.button3_SEC.Text = "SEC";
            this.button3_SEC.UseVisualStyleBackColor = true;
            this.button3_SEC.Click += new System.EventHandler(this.button1_HOUR_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(272, 246);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "ON";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_HOUR_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 293);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3_SEC);
            this.Controls.Add(this.button2_MIN);
            this.Controls.Add(this.button1_HOUR);
            this.Controls.Add(this.label1_MainTimer);
            this.Controls.Add(this.button1_Reset);
            this.Controls.Add(this.button2_stop);
            this.Controls.Add(this.button1_start);
            this.Controls.Add(this.label1_Date);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1_Date;
        private System.Windows.Forms.Button button1_start;
        private System.Windows.Forms.Button button2_stop;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label1_MainTimer;
        private System.Windows.Forms.Button button1_Reset;
        private System.Windows.Forms.Button button1_HOUR;
        private System.Windows.Forms.Button button2_MIN;
        private System.Windows.Forms.Button button3_SEC;
        private System.Windows.Forms.Button button1;
    }
}

