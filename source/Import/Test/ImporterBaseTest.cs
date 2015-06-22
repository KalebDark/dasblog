using newtelligence.DasBlog.Runtime;
using newtelligence.DasBlog.Util;
using NUnit.Framework;
using System.IO;

namespace DasBlog.Import.Test {
	public class ImporterBaseTest {
		[SetUp]
		public virtual void SetUp() {
			if(!Directory.Exists(ContentDirectory)) {
				Directory.CreateDirectory(ContentDirectory);
			}

			DataService = BlogDataServiceFactory.GetService(ContentDirectory, null);

		}
		[TearDown]
		public virtual void TearDown() {
			if(Directory.Exists(ContentDirectory)) {
				Directory.Delete(ContentDirectory, true);
			}

			DataService = null;
		}

		public static string ContentDirectory {
			[System.Diagnostics.DebuggerStepThrough()]
			get {
				return _contentDirectory;
			}
			[System.Diagnostics.DebuggerStepThrough()]
			set {
				_contentDirectory = value;
			}
		}
		private static string _contentDirectory = ReflectionHelper.CodeBase() + "Radio\\ContentDir";

		// Note: This method is not CLS compliant if specified as public.
		internal static IBlogDataService DataService {
			[System.Diagnostics.DebuggerStepThrough()]
			get;
			[System.Diagnostics.DebuggerStepThrough()]
			set; }
	}
}