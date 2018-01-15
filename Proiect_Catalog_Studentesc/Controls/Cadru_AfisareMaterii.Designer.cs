namespace Proiect_Catalog_Studentesc.Controls
{
    partial class Cadru_AfisareMaterii
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bunifuCustomDataGrid1 = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.bunifuFlatButton1 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.Column_NumeMaterie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ProcentCurs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ProcentLaborator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ProcentTeme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ProcentProiect = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Examen = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column_Credite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Sesiune = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Button = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuCustomDataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuCustomDataGrid1
            // 
            this.bunifuCustomDataGrid1.AllowUserToAddRows = false;
            this.bunifuCustomDataGrid1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bunifuCustomDataGrid1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.bunifuCustomDataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(244)))), ((int)(((byte)(239)))));
            this.bunifuCustomDataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bunifuCustomDataGrid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(189)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(244)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bunifuCustomDataGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.bunifuCustomDataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bunifuCustomDataGrid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_NumeMaterie,
            this.Column_ProcentCurs,
            this.Column_ProcentLaborator,
            this.Column_ProcentTeme,
            this.Column_ProcentProiect,
            this.Column_Examen,
            this.Column_Credite,
            this.Column_Sesiune,
            this.Button});
            this.bunifuCustomDataGrid1.DoubleBuffered = true;
            this.bunifuCustomDataGrid1.EnableHeadersVisualStyles = false;
            this.bunifuCustomDataGrid1.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(189)))), ((int)(((byte)(177)))));
            this.bunifuCustomDataGrid1.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(244)))), ((int)(((byte)(239)))));
            this.bunifuCustomDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.bunifuCustomDataGrid1.Name = "bunifuCustomDataGrid1";
            this.bunifuCustomDataGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.bunifuCustomDataGrid1.Size = new System.Drawing.Size(1120, 481);
            this.bunifuCustomDataGrid1.TabIndex = 0;
            this.bunifuCustomDataGrid1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bunifuCustomDataGrid1_CellContentClick);
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
            this.bunifuFlatButton1.Location = new System.Drawing.Point(34, 538);
            this.bunifuFlatButton1.Name = "bunifuFlatButton1";
            this.bunifuFlatButton1.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(165)))), ((int)(((byte)(171)))));
            this.bunifuFlatButton1.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(189)))), ((int)(((byte)(177)))));
            this.bunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(165)))), ((int)(((byte)(171)))));
            this.bunifuFlatButton1.selected = false;
            this.bunifuFlatButton1.Size = new System.Drawing.Size(129, 48);
            this.bunifuFlatButton1.TabIndex = 1;
            this.bunifuFlatButton1.Text = "Back";
            this.bunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatButton1.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(244)))), ((int)(((byte)(239)))));
            this.bunifuFlatButton1.TextFont = new System.Drawing.Font("Broadway", 14.25F);
            this.bunifuFlatButton1.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
            // 
            // Column_NumeMaterie
            // 
            this.Column_NumeMaterie.HeaderText = "Materie";
            this.Column_NumeMaterie.Name = "Column_NumeMaterie";
            this.Column_NumeMaterie.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column_NumeMaterie.Width = 250;
            // 
            // Column_ProcentCurs
            // 
            this.Column_ProcentCurs.HeaderText = "Procent Curs";
            this.Column_ProcentCurs.Name = "Column_ProcentCurs";
            this.Column_ProcentCurs.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column_ProcentCurs.Width = 110;
            // 
            // Column_ProcentLaborator
            // 
            this.Column_ProcentLaborator.HeaderText = "Procent Laborator";
            this.Column_ProcentLaborator.Name = "Column_ProcentLaborator";
            this.Column_ProcentLaborator.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column_ProcentLaborator.Width = 110;
            // 
            // Column_ProcentTeme
            // 
            this.Column_ProcentTeme.HeaderText = "Procent Teme";
            this.Column_ProcentTeme.Name = "Column_ProcentTeme";
            this.Column_ProcentTeme.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Column_ProcentProiect
            // 
            this.Column_ProcentProiect.HeaderText = "Procent Proiect";
            this.Column_ProcentProiect.Name = "Column_ProcentProiect";
            this.Column_ProcentProiect.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Column_Examen
            // 
            this.Column_Examen.HeaderText = "Examen";
            this.Column_Examen.Name = "Column_Examen";
            this.Column_Examen.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column_Examen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column_Credite
            // 
            this.Column_Credite.HeaderText = "Credite";
            this.Column_Credite.Name = "Column_Credite";
            this.Column_Credite.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Column_Sesiune
            // 
            this.Column_Sesiune.HeaderText = "Sesiune";
            this.Column_Sesiune.Name = "Column_Sesiune";
            this.Column_Sesiune.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Button
            // 
            this.Button.HeaderText = "NoteStudenti";
            this.Button.Name = "Button";
            this.Button.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Button.Text = "Note";
            this.Button.UseColumnTextForButtonValue = true;
            this.Button.Width = 109;
            // 
            // Cadru_AfisareMaterii
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(244)))), ((int)(((byte)(239)))));
            this.Controls.Add(this.bunifuFlatButton1);
            this.Controls.Add(this.bunifuCustomDataGrid1);
            this.Name = "Cadru_AfisareMaterii";
            this.Size = new System.Drawing.Size(1120, 603);
            this.Load += new System.EventHandler(this.Cadru_AfisareMaterii_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Cadru_AfisareMaterii_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Cadru_AfisareMaterii_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Cadru_AfisareMaterii_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuCustomDataGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCustomDataGrid bunifuCustomDataGrid1;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_NumeMaterie;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ProcentCurs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ProcentLaborator;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ProcentTeme;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ProcentProiect;
        private System.Windows.Forms.DataGridViewImageColumn Column_Examen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Credite;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Sesiune;
        private System.Windows.Forms.DataGridViewButtonColumn Button;
    }
}
