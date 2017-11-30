namespace TelerikWinFormsApp1
{
    partial class RadForm1
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition6 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.radTextBox1 = new Telerik.WinControls.UI.RadTextBox();
            this.radDropDownButton1 = new Telerik.WinControls.UI.RadDropDownButton();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.radToggleButton1 = new Telerik.WinControls.UI.RadToggleButton();
            this.radRadioButton1 = new Telerik.WinControls.UI.RadRadioButton();
            this.radRepeatButton1 = new Telerik.WinControls.UI.RadRepeatButton();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDropDownButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radToggleButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRepeatButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGridView1
            // 
            this.radGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radGridView1.EnableCustomFiltering = true;
            this.radGridView1.EnableCustomGrouping = true;
            this.radGridView1.EnableCustomSorting = true;
            this.radGridView1.EnableFastScrolling = true;
            this.radGridView1.EnableKeyMap = true;
            this.radGridView1.EnableKineticScrolling = true;
            this.radGridView1.Location = new System.Drawing.Point(0, 246);
            // 
            // 
            // 
            this.radGridView1.MasterTemplate.EnableAlternatingRowColor = true;
            this.radGridView1.MasterTemplate.EnableCustomFiltering = true;
            this.radGridView1.MasterTemplate.EnableCustomGrouping = true;
            this.radGridView1.MasterTemplate.EnableCustomSorting = true;
            this.radGridView1.MasterTemplate.EnableFiltering = true;
            this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition6;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.Size = new System.Drawing.Size(501, 139);
            this.radGridView1.TabIndex = 0;
            this.radGridView1.Text = "radGridView1";
            // 
            // radTextBox1
            // 
            this.radTextBox1.Location = new System.Drawing.Point(25, 12);
            this.radTextBox1.Name = "radTextBox1";
            this.radTextBox1.NullText = "Enter something";
            this.radTextBox1.ShowClearButton = true;
            this.radTextBox1.Size = new System.Drawing.Size(193, 20);
            this.radTextBox1.TabIndex = 1;
            // 
            // radDropDownButton1
            // 
            this.radDropDownButton1.ArrowDirection = Telerik.WinControls.ArrowDirection.Left;
            this.radDropDownButton1.Location = new System.Drawing.Point(25, 39);
            this.radDropDownButton1.Name = "radDropDownButton1";
            this.radDropDownButton1.Size = new System.Drawing.Size(140, 24);
            this.radDropDownButton1.TabIndex = 2;
            this.radDropDownButton1.Text = "radDropDownButton1";
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(183, 38);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(110, 43);
            this.radButton1.TabIndex = 3;
            this.radButton1.Text = "hfahsdkfhaksdhfkahsdf";
            this.radButton1.TextWrap = true;
            // 
            // radToggleButton1
            // 
            this.radToggleButton1.Location = new System.Drawing.Point(25, 82);
            this.radToggleButton1.Name = "radToggleButton1";
            this.radToggleButton1.Size = new System.Drawing.Size(110, 24);
            this.radToggleButton1.TabIndex = 4;
            this.radToggleButton1.Text = "radToggleButton1";
            // 
            // radRadioButton1
            // 
            this.radRadioButton1.Location = new System.Drawing.Point(159, 87);
            this.radRadioButton1.Name = "radRadioButton1";
            this.radRadioButton1.Size = new System.Drawing.Size(105, 18);
            this.radRadioButton1.TabIndex = 5;
            this.radRadioButton1.Text = "radRadioButton1";
            // 
            // radRepeatButton1
            // 
            this.radRepeatButton1.Location = new System.Drawing.Point(289, 81);
            this.radRepeatButton1.Name = "radRepeatButton1";
            this.radRepeatButton1.Size = new System.Drawing.Size(110, 24);
            this.radRepeatButton1.TabIndex = 6;
            this.radRepeatButton1.Text = "radRepeatButton1";
            // 
            // RadForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 385);
            this.Controls.Add(this.radRepeatButton1);
            this.Controls.Add(this.radRadioButton1);
            this.Controls.Add(this.radToggleButton1);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.radDropDownButton1);
            this.Controls.Add(this.radTextBox1);
            this.Controls.Add(this.radGridView1);
            this.Name = "RadForm1";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "RadForm1";
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDropDownButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radToggleButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRepeatButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.UI.RadTextBox radTextBox1;
        private Telerik.WinControls.UI.RadDropDownButton radDropDownButton1;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadToggleButton radToggleButton1;
        private Telerik.WinControls.UI.RadRadioButton radRadioButton1;
        private Telerik.WinControls.UI.RadRepeatButton radRepeatButton1;
    }
}