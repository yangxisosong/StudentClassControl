namespace StudentClassControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(880, 96);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(390, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(504, 144);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(145, 44);
            this.button.TabIndex = 1;
            this.button.Text = "导入";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.Button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(733, 44);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(185, 135);
            this.textBox1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(504, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 44);
            this.button1.TabIndex = 3;
            this.button1.Text = "导出";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(504, 96);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(1042, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(164, 139);
            this.panel1.TabIndex = 5;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.CausesValidation = false;
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 140);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "用户信息";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(78, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "311509080222";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(78, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "null";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(13, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "学号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(13, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名：";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 187);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(231, 554);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "功能选项";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(132)))), ((int)(((byte)(254)))));
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(36, 296);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(106, 44);
            this.button5.TabIndex = 2;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(132)))), ((int)(((byte)(254)))));
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(36, 174);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(106, 44);
            this.button4.TabIndex = 1;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(132)))), ((int)(((byte)(254)))));
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(36, 69);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(106, 44);
            this.button3.TabIndex = 0;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(296, 205);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(970, 540);
            this.panel2.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1282, 753);
            this.Controls.Add(this.button);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel2;
    }
}

