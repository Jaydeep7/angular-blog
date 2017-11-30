using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DemoCancel
{
	public partial class fmProgress : Form
	{
		private bool m_Cancel = false;

		public bool Cancel
		{
			get { return m_Cancel; }
		}

		public fmProgress()
		{
			InitializeComponent();
		}

		private void fmProgress_FormClosing( object sender, FormClosingEventArgs e )
		{
			// If the user clicks the X or hit's Alt+F4 consider this a cancel
			// but don't let the form close, otherwise we can't check the Cancel
			// property because the form will be null.
			m_Cancel = true;
			e.Cancel = true;
		}
	}
}