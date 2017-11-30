namespace DemoCancel
{
	partial class fmMain
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( fmMain ) );
			this.bnSync = new System.Windows.Forms.Button();
			this.bnAsync = new System.Windows.Forms.Button();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.lblStatus = new System.Windows.Forms.Label();
			this.lblExample1 = new System.Windows.Forms.Label();
			this.lblExample2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// bnSync
			// 
			this.bnSync.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.bnSync.Location = new System.Drawing.Point( 257, 12 );
			this.bnSync.Name = "bnSync";
			this.bnSync.Size = new System.Drawing.Size( 162, 39 );
			this.bnSync.TabIndex = 0;
			this.bnSync.Text = "Start Long Running Sychronous Process";
			this.bnSync.UseVisualStyleBackColor = true;
			this.bnSync.Click += new System.EventHandler( this.bnSync_Click );
			// 
			// bnAsync
			// 
			this.bnAsync.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.bnAsync.Location = new System.Drawing.Point( 257, 118 );
			this.bnAsync.Name = "bnAsync";
			this.bnAsync.Size = new System.Drawing.Size( 162, 39 );
			this.bnAsync.TabIndex = 0;
			this.bnAsync.Text = "Start Long Running Asychronous Process";
			this.bnAsync.UseVisualStyleBackColor = true;
			this.bnAsync.Click += new System.EventHandler( this.bnAsync_Click );
			// 
			// progressBar1
			// 
			this.progressBar1.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.progressBar1.Location = new System.Drawing.Point( 97, 200 );
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size( 340, 17 );
			this.progressBar1.TabIndex = 2;
			// 
			// lblStatus
			// 
			this.lblStatus.Location = new System.Drawing.Point( 21, 200 );
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size( 69, 13 );
			this.lblStatus.TabIndex = 1;
			this.lblStatus.Text = "Stopped";
			// 
			// lblExample1
			// 
			this.lblExample1.Location = new System.Drawing.Point( 21, 9 );
			this.lblExample1.Name = "lblExample1";
			this.lblExample1.Size = new System.Drawing.Size( 230, 60 );
			this.lblExample1.TabIndex = 3;
			this.lblExample1.Text = "Example 1: Perform a long running process on a background thread while showing a " +
				"modal Progress Window that allows the user to cancel the process.";
			// 
			// lblExample2
			// 
			this.lblExample2.Location = new System.Drawing.Point( 21, 118 );
			this.lblExample2.Name = "lblExample2";
			this.lblExample2.Size = new System.Drawing.Size( 230, 60 );
			this.lblExample2.TabIndex = 3;
			this.lblExample2.Text = resources.GetString( "lblExample2.Text" );
			// 
			// fmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 449, 234 );
			this.Controls.Add( this.lblExample2 );
			this.Controls.Add( this.lblExample1 );
			this.Controls.Add( this.lblStatus );
			this.Controls.Add( this.progressBar1 );
			this.Controls.Add( this.bnAsync );
			this.Controls.Add( this.bnSync );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "fmMain";
			this.Text = "Demo Cancel";
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.Button bnSync;
		private System.Windows.Forms.Button bnAsync;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.Label lblExample1;
		private System.Windows.Forms.Label lblExample2;
	}
}

