using System.Drawing;
using System.Windows.Forms;

namespace osu__SV_helper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MakeButton = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.version = new System.Windows.Forms.Label();
            this.artist = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.startpoint = new System.Windows.Forms.TextBox();
            this.endpoint = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.endButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.startSV = new System.Windows.Forms.TextBox();
            this.endSV = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.snap = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // MakeButton
            // 
            this.MakeButton.Location = new System.Drawing.Point(269, 441);
            this.MakeButton.Name = "MakeButton";
            this.MakeButton.Size = new System.Drawing.Size(133, 52);
            this.MakeButton.TabIndex = 0;
            this.MakeButton.Text = "作成";
            this.MakeButton.UseVisualStyleBackColor = true;
            this.MakeButton.Click += new System.EventHandler(this.MakeButton_Click);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.Color.Transparent;
            this.title.ForeColor = System.Drawing.Color.White;
            this.title.Location = new System.Drawing.Point(4, 59);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(59, 24);
            this.title.TabIndex = 1;
            this.title.Text = "TITLE";
            // 
            // version
            // 
            this.version.AutoSize = true;
            this.version.BackColor = System.Drawing.Color.Transparent;
            this.version.ForeColor = System.Drawing.Color.White;
            this.version.Location = new System.Drawing.Point(309, 9);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(93, 29);
            this.version.TabIndex = 5;
            this.version.Text = "version";
            // 
            // artist
            // 
            this.artist.AutoSize = true;
            this.artist.BackColor = System.Drawing.Color.Transparent;
            this.artist.ForeColor = System.Drawing.Color.White;
            this.artist.Location = new System.Drawing.Point(4, 80);
            this.artist.Name = "artist";
            this.artist.Size = new System.Drawing.Size(58, 18);
            this.artist.TabIndex = 7;
            this.artist.Text = "Artist";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(390, 102);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "Start Point";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(247, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "End Point";
            // 
            // startpoint
            // 
            this.startpoint.Location = new System.Drawing.Point(86, 179);
            this.startpoint.Name = "startpoint";
            this.startpoint.Size = new System.Drawing.Size(125, 19);
            this.startpoint.TabIndex = 12;
            this.startpoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // endpoint
            // 
            this.endpoint.Location = new System.Drawing.Point(251, 179);
            this.endpoint.Name = "endpoint";
            this.endpoint.Size = new System.Drawing.Size(125, 19);
            this.endpoint.TabIndex = 13;
            this.endpoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(86, 211);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(125, 23);
            this.startButton.TabIndex = 14;
            this.startButton.Text = "set start time";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // endButton
            // 
            this.endButton.Location = new System.Drawing.Point(251, 211);
            this.endButton.Name = "endButton";
            this.endButton.Size = new System.Drawing.Size(125, 23);
            this.endButton.TabIndex = 15;
            this.endButton.Text = "set end time";
            this.endButton.UseVisualStyleBackColor = true;
            this.endButton.Click += new System.EventHandler(this.endButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "Time:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "SV: ";
            // 
            // startSV
            // 
            this.startSV.Location = new System.Drawing.Point(86, 247);
            this.startSV.Name = "startSV";
            this.startSV.Size = new System.Drawing.Size(125, 19);
            this.startSV.TabIndex = 18;
            this.startSV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // endSV
            // 
            this.endSV.Location = new System.Drawing.Point(251, 249);
            this.endSV.Name = "endSV";
            this.endSV.Size = new System.Drawing.Size(125, 19);
            this.endSV.TabIndex = 19;
            this.endSV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1, 292);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 12);
            this.label5.TabIndex = 20;
            this.label5.Text = "Volume: ";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(86, 289);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(125, 19);
            this.textBox3.TabIndex = 21;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(251, 289);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(125, 19);
            this.textBox4.TabIndex = 22;
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(219, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 23;
            this.label6.Text = "→";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(219, 247);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 24;
            this.label7.Text = "→";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(219, 287);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 25;
            this.label8.Text = "→";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 328);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 12);
            this.label9.TabIndex = 26;
            this.label9.Text = "Snap: ";
            // 
            // snap
            // 
            this.snap.Location = new System.Drawing.Point(133, 326);
            this.snap.Name = "snap";
            this.snap.Size = new System.Drawing.Size(39, 19);
            this.snap.TabIndex = 27;
            this.snap.Text = "4";
            this.snap.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(87, 328);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 28;
            this.label10.Text = "1  / ";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(249, 324);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(74, 16);
            this.checkBox1.TabIndex = 29;
            this.checkBox1.Text = "Kiai mode";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(152, 441);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 52);
            this.button1.TabIndex = 30;
            this.button1.Text = "リセット";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(249, 342);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(126, 16);
            this.checkBox2.TabIndex = 31;
            this.checkBox2.Text = "Geometric Ratio SV";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(249, 360);
            this.checkBox3.Name = "autominus";
            this.checkBox3.Size = new System.Drawing.Size(126, 16);
            this.checkBox3.TabIndex = 31;
            this.checkBox3.Text = "Auto minus Offset";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(86, 367);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 19);
            this.textBox1.TabIndex = 32;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 370);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 12);
            this.label11.TabIndex = 33;
            this.label11.Text = "Offset:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 441);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 52);
            this.button2.TabIndex = 34;
            this.button2.Text = "取り消し";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(25, 409);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 12);
            this.label12.TabIndex = 35;
            this.label12.Text = "Mode:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Overwrite(上書き)",
            "Append(追加)",
            "Preserve(前のデータを優先)",
            "Multiply(重ねがけ)" });
            this.comboBox1.Location = new System.Drawing.Point(84, 406);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(200, 20);
            this.comboBox1.TabIndex = 36;
            //
            // Font
            //
            this.title.Font = new System.Drawing.Font(FontCollection.Families[0], 15F);
            this.MakeButton.Font = new System.Drawing.Font(FontCollection.Families[2], 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.version.Font = new System.Drawing.Font(FontCollection.Families[1], 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.artist.Font = new System.Drawing.Font(FontCollection.Families[0], 13F);
            this.label1.Font = new System.Drawing.Font(FontCollection.Families[1], 13F);
            this.label2.Font = new System.Drawing.Font(FontCollection.Families[1], 13F);
            this.startpoint.Font = new System.Drawing.Font(FontCollection.Families[1], 11.75F);
            this.endpoint.Font = new System.Drawing.Font(FontCollection.Families[1], 11.75F);
            this.startButton.Font = new System.Drawing.Font(FontCollection.Families[1], 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endButton.Font = new System.Drawing.Font(FontCollection.Families[1], 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Font = new System.Drawing.Font(FontCollection.Families[1], 13F);
            this.label4.Font = new System.Drawing.Font(FontCollection.Families[1], 13F);
            this.startSV.Font = new System.Drawing.Font(FontCollection.Families[1], 11.75F);
            this.endSV.Font = new System.Drawing.Font(FontCollection.Families[1], 11.75F);
            this.label5.Font = new System.Drawing.Font(FontCollection.Families[1], 13F);
            this.textBox3.Font = new System.Drawing.Font(FontCollection.Families[1], 11.75F);
            this.textBox4.Font = new System.Drawing.Font(FontCollection.Families[1], 11.75F);
            this.label6.Font = new System.Drawing.Font(FontCollection.Families[1], 16F);
            this.label7.Font = new System.Drawing.Font(FontCollection.Families[1], 16F);
            this.label8.Font = new System.Drawing.Font(FontCollection.Families[1], 16F);
            this.label9.Font = new System.Drawing.Font(FontCollection.Families[1], 13F);
            this.snap.Font = new System.Drawing.Font(FontCollection.Families[1], 11.75F);
            this.label10.Font = new System.Drawing.Font(FontCollection.Families[1], 13F);
            this.checkBox1.Font = new System.Drawing.Font(FontCollection.Families[1], 9.75F);
            this.checkBox2.Font = new System.Drawing.Font(FontCollection.Families[1], 9.75F);
            this.checkBox3.Font = new System.Drawing.Font(FontCollection.Families[1], 9.75F);
            this.label11.Font = new System.Drawing.Font(FontCollection.Families[1], 13F);
            this.textBox1.Font = new System.Drawing.Font(FontCollection.Families[1], 11.75F);
            this.button1.Font = new System.Drawing.Font(FontCollection.Families[2], 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button2.Font = new System.Drawing.Font(FontCollection.Families[2], 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label12.Font = new System.Drawing.Font(FontCollection.Families[1], 11.75F);
            this.comboBox1.Font = new System.Drawing.Font(FontCollection.Families[1], 11.75F);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 505);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.snap);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.endSV);
            this.Controls.Add(this.startSV);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.endButton);
            this.Controls.Add(this.MakeButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.endpoint);
            this.Controls.Add(this.startpoint);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "osu!taiko SV Helper made by Hoshino1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button MakeButton;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label version;
        private System.Windows.Forms.Label artist;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox startpoint;
        private System.Windows.Forms.TextBox endpoint;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button endButton;
        private Label label3;
        private Label label4;
        private TextBox startSV;
        private TextBox endSV;
        private Label label5;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox snap;
        private Label label10;
        private CheckBox checkBox1;
        private Button button1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private TextBox textBox1;
        private Label label11;
        private Button button2;
        private Label label12;
        private ComboBox comboBox1;
    }
}
