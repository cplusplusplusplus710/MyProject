namespace HosuChecker
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
            this.textBox1_value = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3_shift_value = new System.Windows.Forms.TextBox();
            this.button1_start = new System.Windows.Forms.Button();
            this.button2_clear = new System.Windows.Forms.Button();
            this.comboBox1_shift_direction = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label3_before = new System.Windows.Forms.Label();
            this.label3_aftershift = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6_complement = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9_complement_decimal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1_value
            // 
            this.textBox1_value.Location = new System.Drawing.Point(74, 9);
            this.textBox1_value.Name = "textBox1_value";
            this.textBox1_value.Size = new System.Drawing.Size(100, 19);
            this.textBox1_value.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "数字";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "シフト数";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "シフト方向";
            // 
            // textBox3_shift_value
            // 
            this.textBox3_shift_value.Location = new System.Drawing.Point(74, 33);
            this.textBox3_shift_value.Name = "textBox3_shift_value";
            this.textBox3_shift_value.Size = new System.Drawing.Size(100, 19);
            this.textBox3_shift_value.TabIndex = 5;
            // 
            // button1_start
            // 
            this.button1_start.Location = new System.Drawing.Point(207, 55);
            this.button1_start.Name = "button1_start";
            this.button1_start.Size = new System.Drawing.Size(75, 23);
            this.button1_start.TabIndex = 6;
            this.button1_start.Text = "計算";
            this.button1_start.UseVisualStyleBackColor = true;
            this.button1_start.Click += new System.EventHandler(this.button1_start_Click);
            // 
            // button2_clear
            // 
            this.button2_clear.Location = new System.Drawing.Point(302, 55);
            this.button2_clear.Name = "button2_clear";
            this.button2_clear.Size = new System.Drawing.Size(75, 23);
            this.button2_clear.TabIndex = 7;
            this.button2_clear.Text = "クリア";
            this.button2_clear.UseVisualStyleBackColor = true;
            this.button2_clear.Click += new System.EventHandler(this.button2_clear_Click);
            // 
            // comboBox1_shift_direction
            // 
            this.comboBox1_shift_direction.FormattingEnabled = true;
            this.comboBox1_shift_direction.Items.AddRange(new object[] {
            "右",
            "左"});
            this.comboBox1_shift_direction.Location = new System.Drawing.Point(74, 57);
            this.comboBox1_shift_direction.Name = "comboBox1_shift_direction";
            this.comboBox1_shift_direction.Size = new System.Drawing.Size(100, 20);
            this.comboBox1_shift_direction.TabIndex = 8;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 118);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 12);
            this.label13.TabIndex = 10;
            this.label13.Text = "計算前の2進数";
            // 
            // label3_before
            // 
            this.label3_before.AutoSize = true;
            this.label3_before.Location = new System.Drawing.Point(110, 118);
            this.label3_before.Name = "label3_before";
            this.label3_before.Size = new System.Drawing.Size(35, 12);
            this.label3_before.TabIndex = 11;
            this.label3_before.Text = "*****";
            this.label3_before.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3_aftershift
            // 
            this.label3_aftershift.AutoSize = true;
            this.label3_aftershift.Location = new System.Drawing.Point(110, 140);
            this.label3_aftershift.Name = "label3_aftershift";
            this.label3_aftershift.Size = new System.Drawing.Size(35, 12);
            this.label3_aftershift.TabIndex = 15;
            this.label3_aftershift.Text = "*****";
            this.label3_aftershift.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "シフト後の2進数";
            // 
            // label6_complement
            // 
            this.label6_complement.AutoSize = true;
            this.label6_complement.Location = new System.Drawing.Point(110, 164);
            this.label6_complement.Name = "label6_complement";
            this.label6_complement.Size = new System.Drawing.Size(35, 12);
            this.label6_complement.TabIndex = 17;
            this.label6_complement.Text = "*****";
            this.label6_complement.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "補数";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "補数の10進数";
            // 
            // label9_complement_decimal
            // 
            this.label9_complement_decimal.AutoSize = true;
            this.label9_complement_decimal.Location = new System.Drawing.Point(110, 188);
            this.label9_complement_decimal.Name = "label9_complement_decimal";
            this.label9_complement_decimal.Size = new System.Drawing.Size(35, 12);
            this.label9_complement_decimal.TabIndex = 19;
            this.label9_complement_decimal.Text = "*****";
            this.label9_complement_decimal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 254);
            this.Controls.Add(this.label9_complement_decimal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6_complement);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3_aftershift);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3_before);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.comboBox1_shift_direction);
            this.Controls.Add(this.button2_clear);
            this.Controls.Add(this.button1_start);
            this.Controls.Add(this.textBox3_shift_value);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1_value);
            this.Name = "Form1";
            this.Text = "補数計算機";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1_value;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3_shift_value;
        private System.Windows.Forms.Button button1_start;
        private System.Windows.Forms.Button button2_clear;
        private System.Windows.Forms.ComboBox comboBox1_shift_direction;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label3_before;
        private System.Windows.Forms.Label label3_aftershift;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6_complement;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9_complement_decimal;
    }
}

