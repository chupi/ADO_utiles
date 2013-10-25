namespace flavonoides
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvr24h = new System.Windows.Forms.DataGridView();
            this.cbgrup = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbaliment = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvfla = new System.Windows.Forms.DataGridView();
            this.cbgrupfla = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bqfiltror24h = new System.Windows.Forms.Button();
            this.bqfiltrofla = new System.Windows.Forms.Button();
            this.dgvlink = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbbuscar = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbbuscarfla = new System.Windows.Forms.TextBox();
            this.Save = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cbsubgroup = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cbcook_met = new System.Windows.Forms.ComboBox();
            this.lnumber = new System.Windows.Forms.Label();
            this.lestimation = new System.Windows.Forms.Label();
            this.cbvariable = new System.Windows.Forms.ComboBox();
            this.cbname = new System.Windows.Forms.ComboBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvr24h)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvfla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlink)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvr24h
            // 
            this.dgvr24h.AllowUserToAddRows = false;
            this.dgvr24h.AllowUserToDeleteRows = false;
            this.dgvr24h.AllowUserToOrderColumns = true;
            this.dgvr24h.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvr24h.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvr24h.Location = new System.Drawing.Point(12, 147);
            this.dgvr24h.Name = "dgvr24h";
            this.dgvr24h.ReadOnly = true;
            this.dgvr24h.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvr24h.Size = new System.Drawing.Size(665, 218);
            this.dgvr24h.TabIndex = 0;
            this.dgvr24h.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvr24h_CellMouseUp);
            this.dgvr24h.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvr24h_CellMouseEnter);
            this.dgvr24h.Click += new System.EventHandler(this.dgvr24h_Click);
            this.dgvr24h.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvr24h_CellContentClick);
            // 
            // cbgrup
            // 
            this.cbgrup.FormattingEnabled = true;
            this.cbgrup.Location = new System.Drawing.Point(118, 12);
            this.cbgrup.Name = "cbgrup";
            this.cbgrup.Size = new System.Drawing.Size(247, 21);
            this.cbgrup.TabIndex = 1;
            this.cbgrup.SelectedIndexChanged += new System.EventHandler(this.cbgrup_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Food Group:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cbaliment
            // 
            this.cbaliment.FormattingEnabled = true;
            this.cbaliment.Location = new System.Drawing.Point(118, 39);
            this.cbaliment.Name = "cbaliment";
            this.cbaliment.Size = new System.Drawing.Size(247, 21);
            this.cbaliment.TabIndex = 3;
            this.cbaliment.SelectedIndexChanged += new System.EventHandler(this.cbaliment_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "food name:";
            // 
            // dgvfla
            // 
            this.dgvfla.AllowUserToAddRows = false;
            this.dgvfla.AllowUserToDeleteRows = false;
            this.dgvfla.AllowUserToOrderColumns = true;
            this.dgvfla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvfla.Location = new System.Drawing.Point(704, 149);
            this.dgvfla.Name = "dgvfla";
            this.dgvfla.ReadOnly = true;
            this.dgvfla.Size = new System.Drawing.Size(549, 216);
            this.dgvfla.TabIndex = 5;
            // 
            // cbgrupfla
            // 
            this.cbgrupfla.FormattingEnabled = true;
            this.cbgrupfla.Location = new System.Drawing.Point(785, 19);
            this.cbgrupfla.Name = "cbgrupfla";
            this.cbgrupfla.Size = new System.Drawing.Size(240, 21);
            this.cbgrupfla.TabIndex = 6;
            this.cbgrupfla.SelectedIndexChanged += new System.EventHandler(this.cbgrupfla_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(701, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "food group:";
            // 
            // bqfiltror24h
            // 
            this.bqfiltror24h.Location = new System.Drawing.Point(377, 57);
            this.bqfiltror24h.Name = "bqfiltror24h";
            this.bqfiltror24h.Size = new System.Drawing.Size(75, 23);
            this.bqfiltror24h.TabIndex = 8;
            this.bqfiltror24h.Text = "Drop Filter";
            this.bqfiltror24h.UseVisualStyleBackColor = true;
            this.bqfiltror24h.Click += new System.EventHandler(this.bqfiltror24h_Click);
            // 
            // bqfiltrofla
            // 
            this.bqfiltrofla.Location = new System.Drawing.Point(1035, 56);
            this.bqfiltrofla.Name = "bqfiltrofla";
            this.bqfiltrofla.Size = new System.Drawing.Size(75, 23);
            this.bqfiltrofla.TabIndex = 9;
            this.bqfiltrofla.Text = "Drop Filter";
            this.bqfiltrofla.UseVisualStyleBackColor = true;
            this.bqfiltrofla.Click += new System.EventHandler(this.bqfiltrofla_Click);
            // 
            // dgvlink
            // 
            this.dgvlink.AllowDrop = true;
            this.dgvlink.AllowUserToAddRows = false;
            this.dgvlink.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvlink.Location = new System.Drawing.Point(26, 439);
            this.dgvlink.Name = "dgvlink";
            this.dgvlink.Size = new System.Drawing.Size(1218, 191);
            this.dgvlink.TabIndex = 10;
            this.dgvlink.CellErrorTextChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvlink_CellErrorTextChanged);
            this.dgvlink.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvlink_DataError);
            this.dgvlink.Click += new System.EventHandler(this.dgvlink_Click);
            this.dgvlink.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvlink_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(654, 382);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Linkage";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "food name:";
            // 
            // tbbuscar
            // 
            this.tbbuscar.Location = new System.Drawing.Point(118, 111);
            this.tbbuscar.Name = "tbbuscar";
            this.tbbuscar.Size = new System.Drawing.Size(247, 20);
            this.tbbuscar.TabIndex = 14;
            this.tbbuscar.TextChanged += new System.EventHandler(this.tbbuscar_TextChanged);
            this.tbbuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(701, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "food name:";
            // 
            // tbbuscarfla
            // 
            this.tbbuscarfla.Location = new System.Drawing.Point(785, 104);
            this.tbbuscarfla.Name = "tbbuscarfla";
            this.tbbuscarfla.Size = new System.Drawing.Size(255, 20);
            this.tbbuscarfla.TabIndex = 16;
            this.tbbuscarfla.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(554, 636);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 17;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(701, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "food subgroup:";
            // 
            // cbsubgroup
            // 
            this.cbsubgroup.FormattingEnabled = true;
            this.cbsubgroup.Location = new System.Drawing.Point(785, 64);
            this.cbsubgroup.Name = "cbsubgroup";
            this.cbsubgroup.Size = new System.Drawing.Size(240, 21);
            this.cbsubgroup.TabIndex = 19;
            this.cbsubgroup.SelectedIndexChanged += new System.EventHandler(this.cbsubgroup_SelectedIndexChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(654, 636);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 20;
            this.button3.Text = "back-up";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(754, 636);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 21;
            this.button4.Text = "back-up2";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(864, 392);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "cook method:";
            // 
            // cbcook_met
            // 
            this.cbcook_met.FormattingEnabled = true;
            this.cbcook_met.Location = new System.Drawing.Point(942, 389);
            this.cbcook_met.Name = "cbcook_met";
            this.cbcook_met.Size = new System.Drawing.Size(151, 21);
            this.cbcook_met.TabIndex = 25;
            this.cbcook_met.SelectedIndexChanged += new System.EventHandler(this.cbcook_met_SelectedIndexChanged);
            // 
            // lnumber
            // 
            this.lnumber.AutoSize = true;
            this.lnumber.Location = new System.Drawing.Point(394, 110);
            this.lnumber.Name = "lnumber";
            this.lnumber.Size = new System.Drawing.Size(0, 13);
            this.lnumber.TabIndex = 26;
            // 
            // lestimation
            // 
            this.lestimation.AutoSize = true;
            this.lestimation.Location = new System.Drawing.Point(9, 382);
            this.lestimation.Name = "lestimation";
            this.lestimation.Size = new System.Drawing.Size(0, 13);
            this.lestimation.TabIndex = 27;
            // 
            // cbvariable
            // 
            this.cbvariable.FormattingEnabled = true;
            this.cbvariable.Location = new System.Drawing.Point(167, 72);
            this.cbvariable.Name = "cbvariable";
            this.cbvariable.Size = new System.Drawing.Size(198, 21);
            this.cbvariable.TabIndex = 29;
            this.cbvariable.SelectedIndexChanged += new System.EventHandler(this.cbvariable_SelectedIndexChanged);
            // 
            // cbname
            // 
            this.cbname.FormattingEnabled = true;
            this.cbname.Location = new System.Drawing.Point(26, 72);
            this.cbname.Name = "cbname";
            this.cbname.Size = new System.Drawing.Size(121, 21);
            this.cbname.TabIndex = 30;
            this.cbname.SelectedIndexChanged += new System.EventHandler(this.cbname_SelectedIndexChanged);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 665);
            this.splitter1.TabIndex = 31;
            this.splitter1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(394, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "---------------------------------------------------------------------------------" +
                "------------------------------------------------";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 665);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.cbname);
            this.Controls.Add(this.cbvariable);
            this.Controls.Add(this.lestimation);
            this.Controls.Add(this.lnumber);
            this.Controls.Add(this.cbcook_met);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.cbsubgroup);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.tbbuscarfla);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbbuscar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvlink);
            this.Controls.Add(this.bqfiltrofla);
            this.Controls.Add(this.bqfiltror24h);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbgrupfla);
            this.Controls.Add(this.dgvfla);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbaliment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbgrup);
            this.Controls.Add(this.dgvr24h);
            this.Name = "Form1";
            this.Text = "Phenol_link";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvr24h)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvfla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlink)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvr24h;
        private System.Windows.Forms.ComboBox cbgrup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbaliment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvfla;
        private System.Windows.Forms.ComboBox cbgrupfla;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bqfiltror24h;
        private System.Windows.Forms.Button bqfiltrofla;
        private System.Windows.Forms.DataGridView dgvlink;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbbuscar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbbuscarfla;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbsubgroup;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbcook_met;
        private System.Windows.Forms.Label lnumber;
        private System.Windows.Forms.Label lestimation;
        private System.Windows.Forms.ComboBox cbvariable;
        private System.Windows.Forms.ComboBox cbname;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label label8;
    }
}

