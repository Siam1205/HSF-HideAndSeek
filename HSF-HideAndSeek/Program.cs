﻿using HSF_HideAndSeek.Forms;
using System;
using System.Windows.Forms;

namespace HSF_HideAndSeek {

	/// <summary>
	/// Main class which runs the application.
	/// It only consists of the main method
	/// </summary>
	static class Program {
		
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Mainframe());
		}
	}
}
