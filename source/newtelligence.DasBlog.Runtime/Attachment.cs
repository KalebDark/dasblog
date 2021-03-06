#region Copyright (c) 2003, newtelligence AG. All rights reserved.

/*
// Copyright (c) 2003, newtelligence AG. (http://www.newtelligence.com)
// Original BlogX Source Code: Copyright (c) 2003, Chris Anderson (http://simplegeek.com)
// All rights reserved.
//  
// Redistribution and use in source and binary forms, with or without modification, are permitted 
// provided that the following conditions are met: 
//  
// (1) Redistributions of source code must retain the above copyright notice, this list of 
// conditions and the following disclaimer. 
// (2) Redistributions in binary form must reproduce the above copyright notice, this list of 
// conditions and the following disclaimer in the documentation and/or other materials 
// provided with the distribution. 
// (3) Neither the name of the newtelligence AG nor the names of its contributors may be used 
// to endorse or promote products derived from this software without specific prior 
// written permission.
//      
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS 
// OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY 
// AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR 
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL 
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, 
// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER 
// IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT 
// OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
// -------------------------------------------------------------------------
//
// Original BlogX source code (c) 2003 by Chris Anderson (http://simplegeek.com)
// 
// newtelligence is a registered trademark of newtelligence Aktiengesellschaft.
// 
// For portions of this software, the some additional copyright notices may apply 
// which can either be found in the license.txt file included in the source distribution
// or following this notice. 
//
*/

#endregion

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace newtelligence.DasBlog.Runtime {
	[XmlRoot(Namespace = Data.NamespaceURI)]
	[XmlType(Namespace = Data.NamespaceURI)]
	[Serializable]
	public class Attachment {
		private string _name;
		private string _url;
		private string _type;
		private long _length;
		private AttachmentType _attachmentType;

		public string Name {
			get { return _name; }
			set { _name = value; }
		}

		[XmlIgnore]
		public string Url {
			get { return _url; }
			set { _url = value; }
		}

		public string Type {
			get { return _type; }
			set { _type = value; }
		}

		public long Length {
			get { return _length; }
			set { _length = value; }
		}

		public AttachmentType AttachmentType {
			get { return _attachmentType; }
			set { _attachmentType = value; }
		}

		[XmlIgnore]
		public bool AttachmentTypeSpecified {
			get { return _attachmentType != AttachmentType.Unknown; }
			set { if(!value) _attachmentType = AttachmentType.Unknown; }
		}


		public Attachment() { }

		public Attachment(string name_, string type_, long length_, AttachmentType attachmentType_) {
			_name = name_;
			_type = type_;
			if(length_ != 0) {
				_length = length_;
			}

			_attachmentType = attachmentType_;
		}
	}

	[Serializable]
	public sealed class AttachmentCollection: Collection<Attachment> {
		// we only one enclose in the attachment collection
		private int _enclosureCount;

		/// <summary>
		/// Initializes a new empty instance of the AttachmentCollection class.
		/// </summary>
		public AttachmentCollection() { }


		/// <summary>
		/// Initializes a new instance of the AttachmentCollection class, wrapping the specified list. 
		/// </summary>
		/// <param name="items_">
		/// The list that is wrapped by the new AttachmentCollection.
		/// </param>
		/// <exception cref="ArgumentException">Thrown when the list contains more than one Enclosure.</exception>
		public AttachmentCollection(IList<Attachment> items_) {
			if(items_ == null) {
				throw new ArgumentNullException("items_");
			}

			AddRange(items_);
		}

		/// <summary>
		/// Adds the elements of an array to the end of this AttachmentCollection.
		/// </summary>
		/// <param name="items_">
		/// The array whose elements are to be added to the end of this AttachmentCollection.
		/// </param>
		public void AddRange(IEnumerable<Attachment> items_) {
			foreach(Attachment item in items_) {
				Add(item);
			}
		}


		protected override void InsertItem(int index_, Attachment item_) {
			Validate(item_);
			base.InsertItem(index_, item_);
			if(IsEnclosure(item_)) {
				_enclosureCount++;
			}
		}

		protected override void SetItem(int index_, Attachment item_) {
			Validate(item_);
			base.SetItem(index_, item_);

			if(IsEnclosure(item_)) {
				_enclosureCount++;
			}
		}

		protected override void ClearItems() {
			base.ClearItems();
			_enclosureCount = 0;
		}

		protected override void RemoveItem(int index_) {

			Attachment item = Items[index_];
			if(item != null && item.AttachmentType == AttachmentType.Enclosure) {
				_enclosureCount--;
			}

			base.RemoveItem(index_);
		}

		// Checks if the number of enclosures doesn't exceed the maximum number
		private void Validate(Attachment item_) {
			if(_enclosureCount > 0 && item_.AttachmentType == AttachmentType.Enclosure) {
				throw new ArgumentException("Only one Enclosure is allowed per collection");
			}
		}

		private static bool IsEnclosure(Attachment item_) {
			return (item_ != null && item_.AttachmentType == AttachmentType.Enclosure);
		}
	}
}
