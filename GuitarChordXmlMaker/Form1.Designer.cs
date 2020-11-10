namespace GuitarChordXmlMaker
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox1_ID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1_Root = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1_degree = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2_position3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3_position2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_position1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox5_position4 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox6_barreflg = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox7_barre = new System.Windows.Forms.TextBox();
            this.button1_Add = new System.Windows.Forms.Button();
            this.button1_Renew = new System.Windows.Forms.Button();
            this.button1_delete = new System.Windows.Forms.Button();
            this.textBox8_high = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Column1_ChordID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1_Root = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1_Degree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1_Positon1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1_Position2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1_Position3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1_Position4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1_BarreFlg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1_Barre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1_High = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1_ChordID,
            this.Column1_Root,
            this.Column1_Degree,
            this.Column1_Positon1,
            this.Column1_Position2,
            this.Column1_Position3,
            this.Column1_Position4,
            this.Column1_BarreFlg,
            this.Column1_Barre,
            this.Column1_High});
            this.dataGridView1.Location = new System.Drawing.Point(15, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(1044, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // textBox1_ID
            // 
            this.textBox1_ID.Location = new System.Drawing.Point(15, 192);
            this.textBox1_ID.Name = "textBox1_ID";
            this.textBox1_ID.Size = new System.Drawing.Size(100, 19);
            this.textBox1_ID.TabIndex = 1;
            this.textBox1_ID.Text = "使わない";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Root";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "ID";
            // 
            // textBox1_Root
            // 
            this.textBox1_Root.Location = new System.Drawing.Point(15, 229);
            this.textBox1_Root.Name = "textBox1_Root";
            this.textBox1_Root.Size = new System.Drawing.Size(100, 19);
            this.textBox1_Root.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 256);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Degree";
            // 
            // textBox1_degree
            // 
            this.textBox1_degree.Location = new System.Drawing.Point(15, 271);
            this.textBox1_degree.Name = "textBox1_degree";
            this.textBox1_degree.Size = new System.Drawing.Size(100, 19);
            this.textBox1_degree.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(148, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "Position3";
            // 
            // textBox2_position3
            // 
            this.textBox2_position3.Location = new System.Drawing.Point(150, 271);
            this.textBox2_position3.Name = "textBox2_position3";
            this.textBox2_position3.Size = new System.Drawing.Size(100, 19);
            this.textBox2_position3.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(148, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "Position2";
            // 
            // textBox3_position2
            // 
            this.textBox3_position2.Location = new System.Drawing.Point(150, 229);
            this.textBox3_position2.Name = "textBox3_position2";
            this.textBox3_position2.Size = new System.Drawing.Size(100, 19);
            this.textBox3_position2.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(148, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "Position1";
            // 
            // textBox_position1
            // 
            this.textBox_position1.Location = new System.Drawing.Point(150, 192);
            this.textBox_position1.Name = "textBox_position1";
            this.textBox_position1.Size = new System.Drawing.Size(100, 19);
            this.textBox_position1.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(283, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "Position4";
            // 
            // textBox5_position4
            // 
            this.textBox5_position4.Location = new System.Drawing.Point(285, 192);
            this.textBox5_position4.Name = "textBox5_position4";
            this.textBox5_position4.Size = new System.Drawing.Size(100, 19);
            this.textBox5_position4.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(283, 214);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "BarreFlg";
            // 
            // textBox6_barreflg
            // 
            this.textBox6_barreflg.Location = new System.Drawing.Point(285, 229);
            this.textBox6_barreflg.Name = "textBox6_barreflg";
            this.textBox6_barreflg.Size = new System.Drawing.Size(100, 19);
            this.textBox6_barreflg.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(283, 256);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 12);
            this.label9.TabIndex = 17;
            this.label9.Text = "Barre";
            // 
            // textBox7_barre
            // 
            this.textBox7_barre.Location = new System.Drawing.Point(285, 271);
            this.textBox7_barre.Name = "textBox7_barre";
            this.textBox7_barre.Size = new System.Drawing.Size(100, 19);
            this.textBox7_barre.TabIndex = 9;
            // 
            // button1_Add
            // 
            this.button1_Add.Location = new System.Drawing.Point(495, 224);
            this.button1_Add.Name = "button1_Add";
            this.button1_Add.Size = new System.Drawing.Size(75, 23);
            this.button1_Add.TabIndex = 11;
            this.button1_Add.Text = "登録";
            this.button1_Add.UseVisualStyleBackColor = true;
            this.button1_Add.Click += new System.EventHandler(this.button1_Add_Click);
            // 
            // button1_Renew
            // 
            this.button1_Renew.Location = new System.Drawing.Point(495, 256);
            this.button1_Renew.Name = "button1_Renew";
            this.button1_Renew.Size = new System.Drawing.Size(75, 23);
            this.button1_Renew.TabIndex = 12;
            this.button1_Renew.Text = "更新";
            this.button1_Renew.UseVisualStyleBackColor = true;
            this.button1_Renew.Click += new System.EventHandler(this.button1_Renew_Click);
            // 
            // button1_delete
            // 
            this.button1_delete.Location = new System.Drawing.Point(495, 285);
            this.button1_delete.Name = "button1_delete";
            this.button1_delete.Size = new System.Drawing.Size(75, 23);
            this.button1_delete.TabIndex = 13;
            this.button1_delete.Text = "削除";
            this.button1_delete.UseVisualStyleBackColor = true;
            this.button1_delete.Click += new System.EventHandler(this.button1_delete_Click);
            // 
            // textBox8_high
            // 
            this.textBox8_high.Location = new System.Drawing.Point(410, 192);
            this.textBox8_high.Name = "textBox8_high";
            this.textBox8_high.Size = new System.Drawing.Size(100, 19);
            this.textBox8_high.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(408, 177);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 12);
            this.label10.TabIndex = 17;
            this.label10.Text = "High";
            // 
            // Column1_ChordID
            // 
            this.Column1_ChordID.HeaderText = "ID";
            this.Column1_ChordID.Name = "Column1_ChordID";
            // 
            // Column1_Root
            // 
            this.Column1_Root.HeaderText = "Root";
            this.Column1_Root.Name = "Column1_Root";
            // 
            // Column1_Degree
            // 
            this.Column1_Degree.HeaderText = "Degree";
            this.Column1_Degree.Name = "Column1_Degree";
            // 
            // Column1_Positon1
            // 
            this.Column1_Positon1.HeaderText = "Position1";
            this.Column1_Positon1.Name = "Column1_Positon1";
            // 
            // Column1_Position2
            // 
            this.Column1_Position2.HeaderText = "Position2";
            this.Column1_Position2.Name = "Column1_Position2";
            // 
            // Column1_Position3
            // 
            this.Column1_Position3.HeaderText = "Position3";
            this.Column1_Position3.Name = "Column1_Position3";
            // 
            // Column1_Position4
            // 
            this.Column1_Position4.HeaderText = "Position4";
            this.Column1_Position4.Name = "Column1_Position4";
            // 
            // Column1_BarreFlg
            // 
            this.Column1_BarreFlg.HeaderText = "BarreFlg";
            this.Column1_BarreFlg.Name = "Column1_BarreFlg";
            // 
            // Column1_Barre
            // 
            this.Column1_Barre.HeaderText = "Barre";
            this.Column1_Barre.Name = "Column1_Barre";
            // 
            // Column1_High
            // 
            this.Column1_High.HeaderText = "High";
            this.Column1_High.Name = "Column1_High";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 450);
            this.Controls.Add(this.button1_delete);
            this.Controls.Add(this.button1_Renew);
            this.Controls.Add(this.button1_Add);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox8_high);
            this.Controls.Add(this.textBox7_barre);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox6_barreflg);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox5_position4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_position1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox3_position2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox2_position3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1_degree);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1_Root);
            this.Controls.Add(this.textBox1_ID);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1_ID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1_Root;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1_degree;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2_position3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3_position2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_position1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox5_position4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox6_barreflg;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox7_barre;
        private System.Windows.Forms.Button button1_Add;
        private System.Windows.Forms.Button button1_Renew;
        private System.Windows.Forms.Button button1_delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1_ChordID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1_Root;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1_Degree;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1_Positon1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1_Position2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1_Position3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1_Position4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1_BarreFlg;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1_Barre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1_High;
        private System.Windows.Forms.TextBox textBox8_high;
        private System.Windows.Forms.Label label10;
    }
}

