namespace DemoCancel
{
	partial class fmProgress
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing && ( components != null ) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.bnCancel = new System.Windows.Forms.Button();
			this.lblDescription = new System.Windows.Forms.Label();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.SuspendLayout();
			// 
			// bnCancel
			// 
			this.bnCancel.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bnCancel.Location = new System.Drawing.Point( 332, 86 );
			this.bnCancel.Name = "bnCancel";
			this.bnCancel.Size = new System.Drawing.Size( 75, 23 );
			this.bnCancel.TabIndex = 0;
			this.bnCancel.Text = "Cancel";
			this.bnCancel.UseVisualStyleBackColor = true;
			// 
			// lblDescription
			// 
			this.lblDescription.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.lblDescription.AutoEllipsis = true;
			this.lblDescription.Location = new System.Drawing.Point( 12, 19 );
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size( 395, 13 );
			this.lblDescription.TabIndex = 1;
			this.lblDescription.Text = "label1";
			// 
			// progressBar1
			// 
			this.progressBar1.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.progressBar1.Location = new System.Drawing.Point( 15, 48 );
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size( 392, 17 );
			this.progressBar1.TabIndex = 2;
			// 
			// fmProgress
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.bnCancel;
			this.ClientSize = new System.Drawing.Size( 419, 121 );
			this.Controls.Add( this.progressBar1 );
			this.Controls.Add( this.lblDescription );
			this.Controls.Add( this.bnCancel );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "fmProgress";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Progress";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.fmProgress_FormClosing );
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.Button bnCancel;
		public System.Windows.Forms.Label lblDescription;
		public System.Windows.Forms.ProgressBar progressBar1;
	}
}