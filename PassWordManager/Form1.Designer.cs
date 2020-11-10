namespace PassWordManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column_ServiceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_PassWord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.更新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.選択を消去DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.マスクMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.昇順AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.昇順AToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.降順DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.コンパクトモードCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1_ServiceName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2_ID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3_PassWord = new System.Windows.Forms.TextBox();
            this.button1_DataAdd = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1_Import = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2_Export = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.pictureBox1_PassWordEye = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1_PassWordEye)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_ServiceName,
            this.Column_ID,
            this.Column_PassWord});
            this.dataGridView1.Location = new System.Drawing.Point(7, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(787, 230);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Column_ServiceName
            // 
            this.Column_ServiceName.HeaderText = "サービス名";
            this.Column_ServiceName.Name = "Column_ServiceName";
            this.Column_ServiceName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column_ServiceName.Width = 367;
            // 
            // Column_ID
            // 
            this.Column_ID.HeaderText = "ID";
            this.Column_ID.Name = "Column_ID";
            this.Column_ID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column_ID.Width = 200;
            // 
            // Column_PassWord
            // 
            this.Column_PassWord.HeaderText = "PassWord";
            this.Column_PassWord.Name = "Column_PassWord";
            this.Column_PassWord.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column_PassWord.Width = 200;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.更新ToolStripMenuItem,
            this.選択を消去DToolStripMenuItem,
            this.マスクMToolStripMenuItem,
            this.昇順AToolStripMenuItem,
            this.コンパクトモードCToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(801, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.menuStrip1_MouseDown);
            this.menuStrip1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.menuStrip1_MouseMove);
            // 
            // 更新ToolStripMenuItem
            // 
            this.更新ToolStripMenuItem.Name = "更新ToolStripMenuItem";
            this.更新ToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.更新ToolStripMenuItem.Text = "更新(&R)";
            this.更新ToolStripMenuItem.Click += new System.EventHandler(this.更新ToolStripMenuItem_Click);
            // 
            // 選択を消去DToolStripMenuItem
            // 
            this.選択を消去DToolStripMenuItem.Name = "選択を消去DToolStripMenuItem";
            this.選択を消去DToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.選択を消去DToolStripMenuItem.Text = "選択を消去(&D)";
            this.選択を消去DToolStripMenuItem.Click += new System.EventHandler(this.選択を消去DToolStripMenuItem_Click);
            // 
            // マスクMToolStripMenuItem
            // 
            this.マスクMToolStripMenuItem.Name = "マスクMToolStripMenuItem";
            this.マスクMToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.マスクMToolStripMenuItem.Text = "マスク(&M)";
            this.マスクMToolStripMenuItem.Click += new System.EventHandler(this.マスクMToolStripMenuItem_Click);
            // 
            // 昇順AToolStripMenuItem
            // 
            this.昇順AToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.昇順AToolStripMenuItem1,
            this.降順DToolStripMenuItem});
            this.昇順AToolStripMenuItem.Name = "昇順AToolStripMenuItem";
            this.昇順AToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.昇順AToolStripMenuItem.Text = "ソート(&S)";
            // 
            // 昇順AToolStripMenuItem1
            // 
            this.昇順AToolStripMenuItem1.Name = "昇順AToolStripMenuItem1";
            this.昇順AToolStripMenuItem1.Size = new System.Drawing.Size(114, 22);
            this.昇順AToolStripMenuItem1.Text = "昇順(&A)";
            this.昇順AToolStripMenuItem1.Click += new System.EventHandler(this.昇順AToolStripMenuItem1_Click);
            // 
            // 降順DToolStripMenuItem
            // 
            this.降順DToolStripMenuItem.Name = "降順DToolStripMenuItem";
            this.降順DToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.降順DToolStripMenuItem.Text = "降順(&D)";
            this.降順DToolStripMenuItem.Click += new System.EventHandler(this.降順DToolStripMenuItem_Click);
            // 
            // コンパクトモードCToolStripMenuItem
            // 
            this.コンパクトモードCToolStripMenuItem.Name = "コンパクトモードCToolStripMenuItem";
            this.コンパクトモードCToolStripMenuItem.Size = new System.Drawing.Size(127, 20);
            this.コンパクトモードCToolStripMenuItem.Text = "コンパクトモード切替(&C)";
            this.コンパクトモードCToolStripMenuItem.Click += new System.EventHandler(this.コンパクトモードCToolStripMenuItem_Click);
            // 
            // textBox1_ServiceName
            // 
            this.textBox1_ServiceName.Location = new System.Drawing.Point(14, 280);
            this.textBox1_ServiceName.Name = "textBox1_ServiceName";
            this.textBox1_ServiceName.Size = new System.Drawing.Size(305, 19);
            this.textBox1_ServiceName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 265);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "サービス名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 302);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "ID";
            // 
            // textBox2_ID
            // 
            this.textBox2_ID.Location = new System.Drawing.Point(14, 317);
            this.textBox2_ID.Name = "textBox2_ID";
            this.textBox2_ID.Size = new System.Drawing.Size(305, 19);
            this.textBox2_ID.TabIndex = 2;
            this.textBox2_ID.TextChanged += new System.EventHandler(this.textBox2_ID_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 339);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "PassWord";
            // 
            // textBox3_PassWord
            // 
            this.textBox3_PassWord.Location = new System.Drawing.Point(12, 354);
            this.textBox3_PassWord.Name = "textBox3_PassWord";
            this.textBox3_PassWord.Size = new System.Drawing.Size(307, 19);
            this.textBox3_PassWord.TabIndex = 3;
            this.textBox3_PassWord.TextChanged += new System.EventHandler(this.textBox3_PassWord_TextChanged);
            // 
            // button1_DataAdd
            // 
            this.button1_DataAdd.Location = new System.Drawing.Point(244, 379);
            this.button1_DataAdd.Name = "button1_DataAdd";
            this.button1_DataAdd.Size = new System.Drawing.Size(75, 23);
            this.button1_DataAdd.TabIndex = 4;
            this.button1_DataAdd.Text = "新規登録";
            this.button1_DataAdd.UseVisualStyleBackColor = true;
            this.button1_DataAdd.Click += new System.EventHandler(this.button1_DataAdd_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(633, 305);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "インポート";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1_Import
            // 
            this.textBox1_Import.Location = new System.Drawing.Point(403, 280);
            this.textBox1_Import.Name = "textBox1_Import";
            this.textBox1_Import.Size = new System.Drawing.Size(305, 19);
            this.textBox1_Import.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(401, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "csvファイルをインポート";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(533, 305);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "ファイルの選択";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox2_Export
            // 
            this.textBox2_Export.Location = new System.Drawing.Point(403, 354);
            this.textBox2_Export.Name = "textBox2_Export";
            this.textBox2_Export.Size = new System.Drawing.Size(305, 19);
            this.textBox2_Export.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(401, 339);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "csvファイルをエクスポート";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(533, 379);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "フォルダーの選択";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(633, 379);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "エクスポート";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // pictureBox1_PassWordEye
            // 
            this.pictureBox1_PassWordEye.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1_PassWordEye.Image = global::PassWordManager.Properties.Resources.medama;
            this.pictureBox1_PassWordEye.Location = new System.Drawing.Point(300, 354);
            this.pictureBox1_PassWordEye.Name = "pictureBox1_PassWordEye";
            this.pictureBox1_PassWordEye.Size = new System.Drawing.Size(19, 19);
            this.pictureBox1_PassWordEye.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1_PassWordEye.TabIndex = 4;
            this.pictureBox1_PassWordEye.TabStop = false;
            this.pictureBox1_PassWordEye.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_PasswordEye_MouseDown);
            this.pictureBox1_PassWordEye.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_PassWordEye_MouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 427);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox2_Export);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1_Import);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button1_DataAdd);
            this.Controls.Add(this.pictureBox1_PassWordEye);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox3_PassWord);
            this.Controls.Add(this.textBox2_ID);
            this.Controls.Add(this.textBox1_ServiceName);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "PassWordManager";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1_PassWordEye)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 更新ToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1_ServiceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ServiceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_PassWord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2_ID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3_PassWord;
        private System.Windows.Forms.PictureBox pictureBox1_PassWordEye;
        private System.Windows.Forms.ToolStripMenuItem 選択を消去DToolStripMenuItem;
        private System.Windows.Forms.Button button1_DataAdd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1_Import;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2_Export;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolStripMenuItem マスクMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 昇順AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 昇順AToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 降順DToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem コンパクトモードCToolStripMenuItem;
    }
}

