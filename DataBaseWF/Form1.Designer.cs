namespace DataBaseWF
{
    partial class FormMulti
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridDB = new System.Windows.Forms.DataGridView();
            this.btncreate = new System.Windows.Forms.Button();
            this.btnread = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.DBSwitch = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDB)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridDB
            // 
            this.dataGridDB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDB.Location = new System.Drawing.Point(9, 54);
            this.dataGridDB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridDB.Name = "dataGridDB";
            this.dataGridDB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridDB.Size = new System.Drawing.Size(688, 310);
            this.dataGridDB.TabIndex = 1;
            this.dataGridDB.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridDB_CellDoubleClick);
            // 
            // btncreate
            // 
            this.btncreate.Location = new System.Drawing.Point(9, 372);
            this.btncreate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btncreate.Name = "btncreate";
            this.btncreate.Size = new System.Drawing.Size(120, 26);
            this.btncreate.TabIndex = 6;
            this.btncreate.Text = "CREATE";
            this.btncreate.UseVisualStyleBackColor = true;
            this.btncreate.Click += new System.EventHandler(this.btncreate_Click);
            // 
            // btnread
            // 
            this.btnread.Location = new System.Drawing.Point(215, 14);
            this.btnread.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnread.Name = "btnread";
            this.btnread.Size = new System.Drawing.Size(120, 26);
            this.btnread.TabIndex = 5;
            this.btnread.Text = "READ";
            this.btnread.UseVisualStyleBackColor = true;
            this.btnread.Click += new System.EventHandler(this.btnread_Click);
            // 
            // btndelete
            // 
            this.btndelete.Location = new System.Drawing.Point(144, 372);
            this.btndelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(120, 26);
            this.btndelete.TabIndex = 7;
            this.btndelete.Text = "DELETE";
            this.btndelete.UseVisualStyleBackColor = true;
            // 
            // DBSwitch
            // 
            this.DBSwitch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DBSwitch.FormattingEnabled = true;
            this.DBSwitch.Location = new System.Drawing.Point(89, 17);
            this.DBSwitch.Name = "DBSwitch";
            this.DBSwitch.Size = new System.Drawing.Size(120, 21);
            this.DBSwitch.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "SELECT DB:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(390, 18);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(181, 20);
            this.txtSearch.TabIndex = 21;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(577, 14);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 26);
            this.btnSearch.TabIndex = 22;
            this.btnSearch.Text = "SEARCH";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // FormMulti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 415);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DBSwitch);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btncreate);
            this.Controls.Add(this.btnread);
            this.Controls.Add(this.dataGridDB);
            this.Name = "FormMulti";
            this.Text = "MultiView";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridDB;
        private System.Windows.Forms.Button btncreate;
        private System.Windows.Forms.Button btnread;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.ComboBox DBSwitch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
    }
}

