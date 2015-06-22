using System;
using System.Collections;

namespace DasBlog.Import.Radio {
	class EntryTable {
		readonly Hashtable _data = new Hashtable();
		string _name;

		public string Name { get { return _name; } set { _name = value; } }
		public string UniqueId { get { return int.Parse(_name).ToString(); } }
		public IDictionary Data { get { return _data; } }
		public DateTime When { get { return (DateTime) Data["when"]; } }
		public string Text { get { return (string) Data["text"]; } }
		public string Title { get { return (string) Data["title"]; } }
		public string Link { get { return (string) Data["link"]; } }
		public string Categories { get { return (string) Data["categories"]; } }
		public bool NotOnHomePage { get { return (bool) Data["flNotOnHomePage"]; } }
	}
}
