namespace WebScrapingTest
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1_URL = new System.Windows.Forms.TextBox();
            this.button1_start = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1_Title = new System.Windows.Forms.TextBox();
            this.textBox1_html = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblView = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1_test = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1_teststart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "URL";
            // 
            // textBox1_URL
            // 
            this.textBox1_URL.Location = new System.Drawing.Point(15, 29);
            this.textBox1_URL.Name = "textBox1_URL";
            this.textBox1_URL.Size = new System.Drawing.Size(404, 19);
            this.textBox1_URL.TabIndex = 1;
            this.textBox1_URL.Text = "http://codezine.jp/";
            // 
            // button1_start
            // 
            this.button1_start.Location = new System.Drawing.Point(462, 24);
            this.button1_start.Name = "button1_start";
            this.button1_start.Size = new System.Drawing.Size(187, 23);
            this.button1_start.TabIndex = 2;
            this.button1_start.Text = "開始";
            this.button1_start.UseVisualStyleBackColor = true;
            this.button1_start.Click += new System.EventHandler(this.button1_start_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Title";
            // 
            // textBox1_Title
            // 
            this.textBox1_Title.Location = new System.Drawing.Point(12, 77);
            this.textBox1_Title.Name = "textBox1_Title";
            this.textBox1_Title.Size = new System.Drawing.Size(637, 19);
            this.textBox1_Title.TabIndex = 1;
            // 
            // textBox1_html
            // 
            this.textBox1_html.Location = new System.Drawing.Point(12, 114);
            this.textBox1_html.Multiline = true;
            this.textBox1_html.Name = "textBox1_html";
            this.textBox1_html.Size = new System.Drawing.Size(637, 247);
            this.textBox1_html.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "HTML";
            // 
            // lblView
            // 
            this.lblView.AutoSize = true;
            this.lblView.Location = new System.Drawing.Point(173, 12);
            this.lblView.Name = "lblView";
            this.lblView.Size = new System.Drawing.Size(0, 12);
            this.lblView.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 373);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "TEST";
            // 
            // textBox1_test
            // 
            this.textBox1_test.Location = new System.Drawing.Point(12, 388);
            this.textBox1_test.Name = "textBox1_test";
            this.textBox1_test.Size = new System.Drawing.Size(637, 19);
            this.textBox1_test.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "記事タイトル取得"});
            this.comboBox1.Location = new System.Drawing.Point(12, 413);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.Text = "テスト用メニュー";
            // 
            // button1_teststart
            // 
            this.button1_teststart.Location = new System.Drawing.Point(139, 413);
            this.button1_teststart.Name = "button1_teststart";
            this.button1_teststart.Size = new System.Drawing.Size(187, 23);
            this.button1_teststart.TabIndex = 5;
            this.button1_teststart.Text = "テスト開始";
            this.button1_teststart.UseVisualStyleBackColor = true;
            this.button1_teststart.Click += new System.EventHandler(this.button1_teststart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 500);
            this.Controls.Add(this.button1_teststart);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lblView);
            this.Controls.Add(this.button1_start);
            this.Controls.Add(this.textBox1_html);
            this.Controls.Add(this.textBox1_test);
            this.Controls.Add(this.textBox1_Title);
            this.Controls.Add(this.textBox1_URL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1_URL;
        private System.Windows.Forms.Button button1_start;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1_Title;
        private System.Windows.Forms.TextBox textBox1_html;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1_test;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1_teststart;
    }
}

