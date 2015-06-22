using System;

namespace DasBlog.Import.Console {
	using Console = System.Console;
	/// <summary>
	/// The class that contains the entry point.
	/// </summary>
	class EntryPoint {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args_) {
			try {
				Import.EntryPoint.DllMain(Environment.CommandLine);
			}
			catch(Exception exception) {
				Console.Error.WriteLine("Error: " + exception.Message);
			}
		}
	}
}
