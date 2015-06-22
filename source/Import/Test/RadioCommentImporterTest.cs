using System;
using System.Diagnostics;
using DasBlog.Import.Test;
using newtelligence.DasBlog.Runtime;
using NUnit.Framework;

namespace DasBlog.Import.Radio.Test {
	[TestFixture]
	public class CommentImporterTest: ImporterBaseTest {

		[SetUp]
		public override void SetUp() {
			base.SetUp();
			EntryImporter.Import(EntryImporterTest.SourceDirectory,
				ContentDirectory);
		}

		public string UserId {
			[DebuggerStepThrough()]
			get {
				return _userId;
			}
			[DebuggerStepThrough()]
			set {
				_userId = value;
			}
		}
		// The userId below belongs to Mark Michaelis (mark@michaelis.net).  Please use
		// it with caution.  Thanks!
		private string _userId = "114349";

		[Test, Ignore("Code not yet completed")]
		public void Import() {

			CommentImporter.Import(UserId, ContentDirectory, null);

			CommentCollection comments = DataService.GetAllComments();
			Assert.AreEqual(15, comments.Count);
		}

		[Test, ExpectedException(typeof(ArgumentException))]
		public void UserIdIsNull() {
			CommentImporter.Import(null, "garbage", null);
		}

		[Test, ExpectedException(typeof(ArgumentException))]
		public void UserIdIsEmpty() {
			CommentImporter.Import("", "garbage", null);
		}

		[Test, ExpectedException(typeof(ArgumentException))]
		public void ContentDirectoryIsNull() {
			CommentImporter.Import("garbage", null, null);
		}

		[Test, ExpectedException(typeof(ArgumentException))]
		public void ContentDirectoryIsEmpty() {
			CommentImporter.Import("garbage", "", null);
		}
	}
}
