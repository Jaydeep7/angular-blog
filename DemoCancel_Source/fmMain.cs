using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace DemoCancel
{
	public partial class fmMain : Form
	{
		// The progress form will be created and shown modally while the
		// Synchronous process is running.  This form will notify the background
		// thread if a Cancellation is performed. The Background thread will update
		// the status label and ProgressBar on the Progress Form using Control.Invoke.
		private fmProgress m_fmProgress = null;

		// The BackgroundWorker will be used to perform a long running action
		// on a background thread.  This allows the UI to be free for painting
		// as well as other actions the user may want to perform.  The Background
		// thread will use the ReportProgress event to update the ProgressBar on the
		// UI thread.
		private BackgroundWorker m_AsyncWorker = new BackgroundWorker();

		public fmMain()
		{
			InitializeComponent();

			// Create a background worker thread that ReportsProgress & SupportsCancellation
			// Hook up the appropriate events.
			m_AsyncWorker.WorkerReportsProgress = true;
			m_AsyncWorker.WorkerSupportsCancellation = true;
			m_AsyncWorker.ProgressChanged += new ProgressChangedEventHandler( bwAsync_ProgressChanged );
			m_AsyncWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler( bwAsync_RunWorkerCompleted );
			m_AsyncWorker.DoWork += new DoWorkEventHandler( bwAsync_DoWork );
		}

		#region Synchronous BackgroundWorker Thread
		
		private void bnSync_Click( object sender, EventArgs e )
		{
			// Create a background thread
			BackgroundWorker bw = new BackgroundWorker();
			bw.DoWork += new DoWorkEventHandler( bw_DoWork );
			bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler( bw_RunWorkerCompleted );

			// Create a progress form on the UI thread
			m_fmProgress = new fmProgress();

			// Kick off the Async thread
			bw.RunWorkerAsync();

			// Lock up the UI with this modal progress form.
			m_fmProgress.ShowDialog( this );
			m_fmProgress = null;
		}

		private void bw_DoWork( object sender, DoWorkEventArgs e )
		{
			// Do some long running task...
			int iCount = new Random().Next( 20, 50 );
			for( int i = 0; i < iCount; i++ )
			{
				// The Work to be performed...
				Thread.Sleep( 100 );

				// Update the description and progress on the modal form
				// using Control.Invoke.  Invoke will run the anonymous
				// function to set the label's text on the UI thread.  
				// Since it's illegal to touch the UI control on the worker 
				// thread that we're on right now.
				// Moron Anonymous functions: http://www.codeproject.com/books/cs2_anonymous_method.asp
				m_fmProgress.lblDescription.Invoke(
					(MethodInvoker) delegate()
					{
						m_fmProgress.lblDescription.Text = "Processing file " + i.ToString() + " of " + iCount.ToString();
						m_fmProgress.progressBar1.Value = Convert.ToInt32( i * ( 100.0 / iCount ) );
					}
				);
				
				// Periodically check for a Cancellation
				// If the user clicks the cancel button, or tries to close
				// the progress form the m_fmProgress.Cancel flag will be set to true.
				if( m_fmProgress.Cancel )
				{
					// Set the e.Cancel flag so that the WorkerCompleted event
					// knows that the process was canceled.
					e.Cancel = true;
					return;
				}
			}
		}

		private void bw_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e )
		{
			// The background process is complete. First we should hide the
			// modal Progress Form to unlock the UI. The we need to inspect our
			// response to see if an error occured, a cancel was requested or
			// if we completed succesfully.

			// Hide the Progress Form
			if( m_fmProgress != null )
			{
				m_fmProgress.Hide();
				m_fmProgress = null;
			}

			// Check to see if an error occured in the 
			// background process.
			if( e.Error != null )
			{
				MessageBox.Show( e.Error.Message );
				return;
			}

			// Check to see if the background process was cancelled.
			if( e.Cancelled )
			{
				MessageBox.Show( "Processing cancelled." );
				return;
			}

			// Everything completed normally.
			// process the response using e.Result
			MessageBox.Show( "Processing is complete." );
		}

		#endregion

		#region Asynchronous BackgroundWorker Thread

		private void bnAsync_Click( object sender, EventArgs e )
		{
			// If the background thread is running then clicking this
			// button causes a cancel, otherwise clicking this button
			// launches the background thread.
			if( m_AsyncWorker.IsBusy )
			{
				bnAsync.Enabled = false;
				lblStatus.Text = "Canceling...";

				// Notify the worker thread that a cancel has been requested.
				// The cancel will not actually happen until the thread in the 
				// DoWork checks the bwAsync.CancellationPending flag, for this
				// reason we set the label to "Canceling...", because we haven't 
				// actually cancelled yet.
				m_AsyncWorker.CancelAsync();
			}
			else
			{
				bnAsync.Text = "Cancel";
				lblStatus.Text = "Running...";

				// Kickoff the worker thread to begin it's DoWork function.
				m_AsyncWorker.RunWorkerAsync();
			}
		}

		private void bwAsync_DoWork( object sender, DoWorkEventArgs e )
		{
			// The Sender is the BackgroundWorker object we need it to
			// report progress and check for cancellation.
			BackgroundWorker bwAsync = sender as BackgroundWorker;

			// Do some long running operation here
			int iCount = new Random().Next( 20, 50 );
			for( int i = 0; i < iCount; i++ )
			{
				// Working...
				Thread.Sleep( 100 );

				// Periodically report progress to the main thread so that it can
				// update the UI.  In most cases you'll just need to send an integer
				// that will update a ProgressBar, but there is an OverLoad for the
				// ReportProgress function so that you can supply some other information
				// as well, perhaps a status label?
				bwAsync.ReportProgress( Convert.ToInt32( i * ( 100.0 / iCount ) ) );

				// Periodically check if a Cancellation request is pending.  If the user
				// clicks cancel the line m_AsyncWorker.CancelAsync(); if ran above.  This
				// sets the CancellationPending to true.  You must check this flag in here and
				// react to it.  We react to it by setting e.Cancel to true and leaving.
				if( bwAsync.CancellationPending )
				{
					// Pause for bit to demonstrate that there is time between 
					// "Cancelling..." and "Canceled".
					Thread.Sleep( 1200 );

					// Set the e.Cancel flag so that the WorkerCompleted event
					// knows that the process was canceled.
					e.Cancel = true;
					return;
				}
			}
			bwAsync.ReportProgress( 100 );
		}

		private void bwAsync_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e )
		{
			// The background process is complete. We need to inspect 
			// our response to see if an error occured, a cancel was 
			// requested or if we completed succesfully.

			bnAsync.Text = "Start Long Running Asychronous Process";
			bnAsync.Enabled = true;

			// Check to see if an error occured in the 
			// background process.
			if( e.Error != null )
			{
				MessageBox.Show( e.Error.Message );
				return;
			}

			// Check to see if the background process was cancelled.
			if( e.Cancelled )
			{
				lblStatus.Text = "Cancelled...";
			}
			else
			{
				// Everything completed normally.
				// process the response using e.Result

				lblStatus.Text = "Completed...";
			}
		}

		private void bwAsync_ProgressChanged( object sender, ProgressChangedEventArgs e )
		{
			// This function fires on the UI thread so it's safe to edit
			// the UI control directly, no funny business with Control.Invoke.
			// Update the progressBar with the integer supplide to us from the 
			// ReportProgress() function.  Note, e.UserState is a "tag" property
			// that can be used to send other information from the BackgroundThread
			// to the UI thread.
			
			progressBar1.Value = e.ProgressPercentage;
		}

		#endregion

	}
}