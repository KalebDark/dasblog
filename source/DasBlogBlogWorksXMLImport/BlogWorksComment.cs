using System;
using System.Collections;
using System.Xml;

namespace Rendelmann.Torsten.DasBlog.BlogWorksXmlImport {
	class BlogWorksComment {
		readonly Hashtable _data = new Hashtable();
		string _name;

		public string Name { get { return _name; } set { _name = value; } }
		public string UniqueId { get { return _name; } }
		public IDictionary Data { get { return _data; } }
		public DateTime When { get { return (DateTime) Data["datetime"]; } }
		public string Text { get { return (string) Data["text"]; } }
		public string AuthorEmail { get { return (string) Data["email"]; } }
		public string Author { get { return (string) Data["name"]; } }
		public string AuthorHomepage { get { return (string) Data["uri"]; } }
		public XmlElement Ip { get { return (XmlElement) Data["ip"]; } }
	}
}