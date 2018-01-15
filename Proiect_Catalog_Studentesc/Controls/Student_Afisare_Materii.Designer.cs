namespace Proiect_Catalog_Studentesc.Controls
{
    partial class Student_Afisare_Materii
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
            this.Column_Materie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_NumeCadru1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Cadru2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Cadru3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Cadru4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ProcentCurs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ProcentLab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ProcentTeme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ProcentProiect = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Examen = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column_Credite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Curs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Laborator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Proiect = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Medie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Admis = new System.Windows.Forms.DataGridViewImageColumn();
            this.bunifuFlatButton2 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuFlatButton1 = new Bunifu.Framework.UI.BunifuFlatButton();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuCustomDataGrid1)).BeginInit();
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
            this.Column_Materie,
            this.Column_NumeCadru1,
            this.Column_Cadru2,
            this.Column_Cadru3,
            this.Column_Cadru4,
            this.Column_ProcentCurs,
            this.Column_ProcentLab,
            this.Column_ProcentTeme,
            this.Column_ProcentProiect,
            this.Column_Examen,
            this.Column_Credite,
            this.Column_Curs,
            this.Column_Laborator,
            this.Column_Proiect,
            this.Column_Medie,
            this.Column_Admis});
            this.bunifuCustomDataGrid1.DoubleBuffered = true;
            this.bunifuCustomDataGrid1.EnableHeadersVisualStyles = false;
            this.bunifuCustomDataGrid1.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(189)))), ((int)(((byte)(177)))));
            this.bunifuCustomDataGrid1.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(244)))), ((int)(((byte)(239)))));
            this.bunifuCustomDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.bunifuCustomDataGrid1.Name = "bunifuCustomDataGrid1";
            this.bunifuCustomDataGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.bunifuCustomDataGrid1.Size = new System.Drawing.Size(1144, 544);
            this.bunifuCustomDataGrid1.TabIndex = 0;
            this.bunifuCustomDataGrid1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bunifuCustomDataGrid1_CellContentClick_1);
            this.bunifuCustomDataGrid1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.bunifuCustomDataGrid1_MouseMove);
            // 
            // Column_Materie
            // 
            this.Column_Materie.HeaderText = "Materie";
            this.Column_Materie.Name = "Column_Materie";
            this.Column_Materie.Width = 90;
            // 
            // Column_NumeCadru1
            // 
            this.Column_NumeCadru1.HeaderText = "Prof Curs1 ";
            this.Column_NumeCadru1.Name = "Column_NumeCadru1";
            this.Column_NumeCadru1.Width = 85;
            // 
            // Column_Cadru2
            // 
            this.Column_Cadru2.HeaderText = "Prof Curs2";
            this.Column_Cadru2.Name = "Column_Cadru2";
            this.Column_Cadru2.Width = 85;
            // 
            // Column_Cadru3
            // 
            this.Column_Cadru3.HeaderText = "Asistent1";
            this.Column_Cadru3.Name = "Column_Cadru3";
            this.Column_Cadru3.Width = 85;
            // 
            // Column_Cadru4
            // 
            this.Column_Cadru4.HeaderText = "Asistent2";
            this.Column_Cadru4.Name = "Column_Cadru4";
            this.Column_Cadru4.Width = 85;
            // 
            // Column_ProcentCurs
            // 
            this.Column_ProcentCurs.HeaderText = "Procent Curs";
            this.Column_ProcentCurs.Name = "Column_ProcentCurs";
            this.Column_ProcentCurs.Width = 60;
            // 
            // Column_ProcentLab
            // 
            this.Column_ProcentLab.HeaderText = "Procent Laborator";
            this.Column_ProcentLab.Name = "Column_ProcentLab";
            this.Column_ProcentLab.Width = 60;
            // 
            // Column_ProcentTeme
            // 
            this.Column_ProcentTeme.HeaderText = "Procent Teme";
            this.Column_ProcentTeme.Name = "Column_ProcentTeme";
            this.Column_ProcentTeme.Width = 60;
            // 
            // Column_ProcentProiect
            // 
            this.Column_ProcentProiect.HeaderText = "Procent Proiect";
            this.Column_ProcentProiect.Name = "Column_ProcentProiect";
            this.Column_ProcentProiect.Width = 60;
            // 
            // Column_Examen
            // 
            this.Column_Examen.HeaderText = "Examen";
            this.Column_Examen.Name = "Column_Examen";
            this.Column_Examen.Width = 65;
            // 
            // Column_Credite
            // 
            this.Column_Credite.HeaderText = "Credite";
            this.Column_Credite.Name = "Column_Credite";
            this.Column_Credite.Width = 60;
            // 
            // Column_Curs
            // 
            this.Column_Curs.HeaderText = "Curs";
            this.Column_Curs.Name = "Column_Curs";
            this.Column_Curs.Width = 50;
            // 
            // Column_Laborator
            // 
            this.Column_Laborator.HeaderText = "Laborator";
            this.Column_Laborator.Name = "Column_Laborator";
            this.Column_Laborator.Width = 75;
            // 
            // Column_Proiect
            // 
            this.Column_Proiect.HeaderText = "Proiect";
            this.Column_Proiect.Name = "Column_Proiect";
            this.Column_Proiect.Width = 55;
            // 
            // Column_Medie
            // 
            this.Column_Medie.HeaderText = "Medie";
            this.Column_Medie.Name = "Column_Medie";
            this.Column_Medie.Width = 50;
            // 
            // Column_Admis
            // 
            this.Column_Admis.HeaderText = "Admis";
            this.Column_Admis.Name = "Column_Admis";
            this.Column_Admis.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_Admis.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column_Admis.Width = 54;
            // 
            // bunifuFlatButton2
            // 
            this.bunifuFlatButton2.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(165)))), ((int)(((byte)(171)))));
            this.bunifuFlatButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(165)))), ((int)(((byte)(171)))));
            this.bunifuFlatButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton2.BorderRadius = 0;
            this.bunifuFlatButton2.ButtonText = "Export";
            this.bunifuFlatButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton2.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton2.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton2.Iconimage = global::Proiect_Catalog_Studentesc.Properties.Resources.export;
            this.bunifuFlatButton2.Iconimage_right = null;
            this.bunifuFlatButton2.Iconimage_right_Selected = null;
            this.bunifuFlatButton2.Iconimage_Selected = null;
            this.bunifuFlatButton2.IconMarginLeft = 0;
            this.bunifuFlatButton2.IconMarginRight = 0;
            this.bunifuFlatButton2.IconRightVisible = true;
            this.bunifuFlatButton2.IconRightZoom = 0D;
            this.bunifuFlatButton2.IconVisible = true;
            this.bunifuFlatButton2.IconZoom = 90D;
            this.bunifuFlatButton2.IsTab = false;
            this.bunifuFlatButton2.Location = new System.Drawing.Point(956, 550);
            this.bunifuFlatButton2.Name = "bunifuFlatButton2";
            this.bunifuFlatButton2.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(165)))), ((int)(((byte)(171)))));
            this.bunifuFlatButton2.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(189)))), ((int)(((byte)(177)))));
            this.bunifuFlatButton2.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(165)))), ((int)(((byte)(171)))));
            this.bunifuFlatButton2.selected = false;
            this.bunifuFlatButton2.Size = new System.Drawing.Size(120, 41);
            this.bunifuFlatButton2.TabIndex = 2;
            this.bunifuFlatButton2.Text = "Export";
            this.bunifuFlatButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatButton2.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(244)))), ((int)(((byte)(239)))));
            this.bunifuFlatButton2.TextFont = new System.Drawing.Font("Broadway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuFlatButton2.Click += new System.EventHandler(this.bunifuFlatButton2_Click);
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
            this.bunifuFlatButton1.Location = new System.Drawing.Point(29, 550);
            this.bunifuFlatButton1.Name = "bunifuFlatButton1";
            this.bunifuFlatButton1.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(165)))), ((int)(((byte)(171)))));
            this.bunifuFlatButton1.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(189)))), ((int)(((byte)(177)))));
            this.bunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(165)))), ((int)(((byte)(171)))));
            this.bunifuFlatButton1.selected = false;
            this.bunifuFlatButton1.Size = new System.Drawing.Size(115, 41);
            this.bunifuFlatButton1.TabIndex = 1;
            this.bunifuFlatButton1.Text = "Back";
            this.bunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatButton1.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(244)))), ((int)(((byte)(239)))));
            this.bunifuFlatButton1.TextFont = new System.Drawing.Font("Broadway", 14.25F);
            this.bunifuFlatButton1.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
            // 
            // Student_Afisare_Materii
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(244)))), ((int)(((byte)(239)))));
            this.Controls.Add(this.bunifuFlatButton2);
            this.Controls.Add(this.bunifuFlatButton1);
            this.Controls.Add(this.bunifuCustomDataGrid1);
            this.Name = "Student_Afisare_Materii";
            this.Size = new System.Drawing.Size(1120, 603);
            this.Load += new System.EventHandler(this.Student_Afisare_Materii_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Student_Afisare_Materii_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Student_Afisare_Materii_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Student_Afisare_Materii_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuCustomDataGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCustomDataGrid bunifuCustomDataGrid1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Materie;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_NumeCadru1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Cadru2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Cadru3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Cadru4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ProcentCurs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ProcentLab;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ProcentTeme;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ProcentProiect;
        private System.Windows.Forms.DataGridViewImageColumn Column_Examen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Credite;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Curs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Laborator;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Proiect;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Medie;
        private System.Windows.Forms.DataGridViewImageColumn Column_Admis;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton1;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton2;
    }
}
