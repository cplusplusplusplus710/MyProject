namespace ChordChecker
{
    partial class MainForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2_Add = new System.Windows.Forms.Button();
            this.button2_Delete = new System.Windows.Forms.Button();
            this.Column1_SiteName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1_URL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("MS UI Gothic", 18F);
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(269, 79);
            this.button1.TabIndex = 0;
            this.button1.Text = "ギターコード";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1_SiteName,
            this.Column1_URL});
            this.dataGridView1.Location = new System.Drawing.Point(12, 124);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(270, 210);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 342);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 357);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(141, 19);
            this.textBox1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 383);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "URL";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 398);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(141, 19);
            this.textBox2.TabIndex = 3;
            // 
            // button2_Add
            // 
            this.button2_Add.Location = new System.Drawing.Point(206, 357);
            this.button2_Add.Name = "button2_Add";
            this.button2_Add.Size = new System.Drawing.Size(75, 23);
            this.button2_Add.TabIndex = 4;
            this.button2_Add.Text = "新規登録";
            this.button2_Add.UseVisualStyleBackColor = true;
            this.button2_Add.Click += new System.EventHandler(this.button2_Add_Click);
            // 
            // button2_Delete
            // 
            this.button2_Delete.Location = new System.Drawing.Point(206, 394);
            this.button2_Delete.Name = "button2_Delete";
            this.button2_Delete.Size = new System.Drawing.Size(75, 23);
            this.button2_Delete.TabIndex = 4;
            this.button2_Delete.Text = "選択を削除";
            this.button2_Delete.UseVisualStyleBackColor = true;
            this.button2_Delete.Click += new System.EventHandler(this.button2_Delete_Click);
            // 
            // Column1_SiteName
            // 
            this.Column1_SiteName.HeaderText = "Name";
            this.Column1_SiteName.Name = "Column1_SiteName";
            this.Column1_SiteName.Width = 120;
            // 
            // Column1_URL
            // 
            this.Column1_URL.HeaderText = "URL";
            this.Column1_URL.Name = "Column1_URL";
            this.Column1_URL.Width = 130;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "コードサイトメモ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 432);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2_Delete);
            this.Controls.Add(this.button2_Add);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Name = "MainForm";
            this.Text = "GuitarChordChecker";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2_Add;
        private System.Windows.Forms.Button button2_Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1_SiteName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1_URL;
        private System.Windows.Forms.Label label3;
    }
}

