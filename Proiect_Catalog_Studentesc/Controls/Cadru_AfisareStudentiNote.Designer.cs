namespace Proiect_Catalog_Studentesc.Controls
{
    partial class Cadru_AfisareStudentiNote
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bunifuCustomDataGrid1 = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.Column_StudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Prenume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Curs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Laborator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Proiect = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Finala = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Promovat = new System.Windows.Forms.DataGridViewImageColumn();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuFlatButton1 = new Bunifu.Framework.UI.BunifuFlatButton();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuCustomDataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuCustomDataGrid1
            // 
            this.bunifuCustomDataGrid1.AllowUserToAddRows = false;
            this.bunifuCustomDataGrid1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bunifuCustomDataGrid1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.bunifuCustomDataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(244)))), ((int)(((byte)(239)))));
            this.bunifuCustomDataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bunifuCustomDataGrid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(189)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(244)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bunifuCustomDataGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.bunifuCustomDataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bunifuCustomDataGrid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_StudentName,
            this.Column_Prenume,
            this.Column_Curs,
            this.Column_Laborator,
            this.Column_Proiect,
            this.Column_Finala,
            this.Column_Promovat});
            this.bunifuCustomDataGrid1.DoubleBuffered = true;
            this.bunifuCustomDataGrid1.EnableHeadersVisualStyles = false;
            this.bunifuCustomDataGrid1.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(189)))), ((int)(((byte)(177)))));
            this.bunifuCustomDataGrid1.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(244)))), ((int)(((byte)(239)))));
            this.bunifuCustomDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.bunifuCustomDataGrid1.Name = "bunifuCustomDataGrid1";
            this.bunifuCustomDataGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.bunifuCustomDataGrid1.Size = new System.Drawing.Size(741, 458);
            this.bunifuCustomDataGrid1.TabIndex = 0;
            // 
            // Column_StudentName
            // 
            this.Column_StudentName.HeaderText = "Nume";
            this.Column_StudentName.Name = "Column_StudentName";
            this.Column_StudentName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Column_Prenume
            // 
            this.Column_Prenume.HeaderText = "Prenume";
            this.Column_Prenume.Name = "Column_Prenume";
            this.Column_Prenume.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Column_Curs
            // 
            this.Column_Curs.HeaderText = "Curs";
            this.Column_Curs.Name = "Column_Curs";
            this.Column_Curs.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Column_Laborator
            // 
            this.Column_Laborator.HeaderText = "Laborator";
            this.Column_Laborator.Name = "Column_Laborator";
            this.Column_Laborator.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Column_Proiect
            // 
            this.Column_Proiect.HeaderText = "Proiect";
            this.Column_Proiect.Name = "Column_Proiect";
            this.Column_Proiect.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Column_Finala
            // 
            this.Column_Finala.HeaderText = "Nota Finala";
            this.Column_Finala.Name = "Column_Finala";
            this.Column_Finala.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Column_Promovat
            // 
            this.Column_Promovat.HeaderText = "Promovat";
            this.Column_Promovat.Name = "Column_Promovat";
            this.Column_Promovat.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Proiect_Catalog_Studentesc.Properties.Resources.creion_00000;
            this.pictureBox4.Location = new System.Drawing.Point(793, 170);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(111, 85);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Proiect_Catalog_Studentesc.Properties.Resources.glob_00000;
            this.pictureBox3.Location = new System.Drawing.Point(999, 133);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(100, 81);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Proiect_Catalog_Studentesc.Properties.Resources.carte_00000;
            this.pictureBox2.Location = new System.Drawing.Point(846, 55);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(147, 121);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Proiect_Catalog_Studentesc.Properties.Resources.student_Note;
            this.pictureBox1.Location = new System.Drawing.Point(771, 270);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(328, 361);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // bunifuFlatButton1
            // 
            this.bunifuFlatButton1.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(165)))), ((int)(((byte)(171)))));
            this.bunifuFlatButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(165)))), ((int)(((byte)(171)))));
            this.bunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton1.BorderRadius = 0;
            this.bunifuFlatButton1.ButtonText = "Back";
            this.bunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton1.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton1.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton1.Iconimage = global::Proiect_Catalog_Studentesc.Properties.Resources.back;
            this.bunifuFlatButton1.Iconimage_right = null;
            this.bunifuFlatButton1.Iconimage_right_Selected = null;
            this.bunifuFlatButton1.Iconimage_Selected = null;
            this.bunifuFlatButton1.IconMarginLeft = 0;
            this.bunifuFlatButton1.IconMarginRight = 0;
            this.bunifuFlatButton1.IconRightVisible = true;
            this.bunifuFlatButton1.IconRightZoom = 0D;
            this.bunifuFlatButton1.IconVisible = true;
            this.bunifuFlatButton1.IconZoom = 90D;
            this.bunifuFlatButton1.IsTab = false;
            this.bunifuFlatButton1.Location = new System.Drawing.Point(32, 536);
            this.bunifuFlatButton1.Name = "bunifuFlatButton1";
            this.bunifuFlatButton1.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(165)))), ((int)(((byte)(171)))));
            this.bunifuFlatButton1.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(189)))), ((int)(((byte)(177)))));
            this.bunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(165)))), ((int)(((byte)(171)))));
            this.bunifuFlatButton1.selected = false;
            this.bunifuFlatButton1.Size = new System.Drawing.Size(120, 48);
            this.bunifuFlatButton1.TabIndex = 1;
            this.bunifuFlatButton1.Text = "Back";
            this.bunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatButton1.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(244)))), ((int)(((byte)(239)))));
            this.bunifuFlatButton1.TextFont = new System.Drawing.Font("Broadway", 14.25F);
            this.bunifuFlatButton1.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
            // 
            // Cadru_AfisareStudentiNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(244)))), ((int)(((byte)(239)))));
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bunifuFlatButton1);
            this.Controls.Add(this.bunifuCustomDataGrid1);
            this.Name = "Cadru_AfisareStudentiNote";
            this.Size = new System.Drawing.Size(1120, 603);
            this.Load += new System.EventHandler(this.Cadru_AfisareStudentiNote_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Cadru_AfisareStudentiNote_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Cadru_AfisareStudentiNote_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Cadru_AfisareStudentiNote_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuCustomDataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCustomDataGrid bunifuCustomDataGrid1;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_StudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Prenume;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Curs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Laborator;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Proiect;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Finala;
        private System.Windows.Forms.DataGridViewImageColumn Column_Promovat;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}
