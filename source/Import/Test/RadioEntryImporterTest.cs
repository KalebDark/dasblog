using System;
using System.Diagnostics;
using DasBlog.Import.Test;
using newtelligence.DasBlog.Util;
using NUnit.Framework;

namespace DasBlog.Import.Radio.Test {
	[TestFixture]
	public class EntryImporterTest: ImporterBaseTest {
		public static string SourceDirectory {
			[DebuggerStepThrough()]
			get {
				return _sourceDirectory;
			}
			[DebuggerStepThrough()]
			set {
				_sourceDirectory = value;
			}
		}
		private static string _sourceDirectory = ReflectionHelper.CodeBase() + "Radio\\SourceDir";

		[Test, Ignore("Test depends on data that does not exist in source control.")]
		public void Import() {

			EntryImporter.Import(SourceDirectory,
				ContentDirectory);

			Assert.AreEqual(3, DataService.GetCategories().Count, "The expected number of categories was not imported.");
			Assert.AreEqual(30, DataService.GetEntriesForDay(DateTime.MaxValue.AddDays(-2), TimeZone.CurrentTimeZone,
				"", int.MaxValue, int.MaxValue, null).Count);

			Assert.AreEqual("First Weblog post and test just to try things out.",
				DataService.GetEntry("1").Content);
			Assert.AreEqual(@"http://www.fawcette.com/vsm/2002_03/online/online_eprods/c_03_08/",
				DataService.GetEntry("21").Link);
		}

		[Test, ExpectedException(typeof(ArgumentException))]
		public void SourceDirectoryIsNull() {
			EntryImporter.Import(null, "garbage");
		}

		[Test, ExpectedException(typeof(ArgumentException))]
		public void ContentDirectoryIsNull() {
			EntryImporter.Import("garbage", null);
		}

		[Test, ExpectedException(typeof(ArgumentException))]
		public void SourceDirectoryIsEmpty() {
			EntryImporter.Import("", "garbage");
		}

		[Test, ExpectedException(typeof(ArgumentException))]
		public void ContentDirectoryIsEmpty() {
			EntryImporter.Import("garbage", "");
		}
	}
}
