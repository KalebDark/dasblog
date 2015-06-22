using System;
using System.Collections;

namespace Rendelmann.Torsten.DasBlog.BlogWorksXmlImport {
	class BlogWorksTable: IComparable {
		readonly Hashtable _data = new Hashtable();
		string _name;

		public string Name { get { return _name; } set { _name = value; } }
		public string UniqueId { get { return _name; } }
		public IDictionary Data { get { return _data; } }
		public DateTime When { get { return (DateTime) Data["timestamp"]; } }
		public string Text { get { return (string) Data["blogbody"]; } }
		public string Title { get { return (string) Data["blogtitle"]; } }
		public string Language { get { return (string) Data["language"]; } }
		public string Categories { get { return (string) Data["categories"]; } }

		public int CompareTo(object obj_) {
			BlogWorksTable other = obj_ as BlogWorksTable;
			if(other != null) {
				return When.CompareTo(other.When);
			}

			return 0;
		}
	}
}