using RJH.CommandLineHelper;

namespace DasBlog.Import {
	/// <summary>
	/// Summary description for CommandLine.
	/// </summary>
	public class CommandLine {
		[CommandLineSwitch("SourceType", "Specify the blog program from which to import content.")]
		public BlogSourceType Source {
			[System.Diagnostics.DebuggerStepThrough()]
			get;
			[System.Diagnostics.DebuggerStepThrough()]
			set;
		}

		[CommandLineSwitch("ContentDir", "The DasBlog content directory into which the entries are placed.")]
		[CommandLineAlias("to")]
		public string ContentDirectory {
			[System.Diagnostics.DebuggerStepThrough()]
			get;
			[System.Diagnostics.DebuggerStepThrough()]
			set;
		}

		[CommandLineSwitch("SourceDir", "The source directory from which content will be imported.")]
		[CommandLineAlias("from")]
		public string SourceDirectory {
			[System.Diagnostics.DebuggerStepThrough()]
			get;
			[System.Diagnostics.DebuggerStepThrough()]
			set;
		}

		[CommandLineSwitch("CommentServer", "An example of the radio comment server is http://radiocomments.userland.com, but you'll need to check your radio html source! Some people are on radiocomments2, etc.")]
		public string CommentServer {
			[System.Diagnostics.DebuggerStepThrough()]
			get;
			[System.Diagnostics.DebuggerStepThrough()]
			set;
		}

		[CommandLineSwitch("UserID", "A radioland userid such as ")]
		public string UserID {
			[System.Diagnostics.DebuggerStepThrough()]
			get;
			[System.Diagnostics.DebuggerStepThrough()]
			set;
		}

		[CommandLineSwitch("Help", "Displays the command line help.")]
		public bool Help {
			[System.Diagnostics.DebuggerStepThrough()]
			get;
			[System.Diagnostics.DebuggerStepThrough()]
			set;
		}

		public CommandLine() {
			Help = false;
		}
	}
}
