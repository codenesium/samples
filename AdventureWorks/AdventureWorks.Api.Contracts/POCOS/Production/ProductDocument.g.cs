using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOProductDocument
	{
		public POCOProductDocument()
		{}

		public POCOProductDocument(int productID,
		                           Guid documentNode,
		                           DateTime modifiedDate)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();

			ProductID = new ReferenceEntity<int>(productID,
			                                     "Product");
			DocumentNode = new ReferenceEntity<Guid>(documentNode,
			                                         "Document");
		}

		public ReferenceEntity<int>ProductID {get; set;}
		public ReferenceEntity<Guid>DocumentNode {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeProductIDValue {get; set;} = true;

		public bool ShouldSerializeProductID()
		{
			return ShouldSerializeProductIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDocumentNodeValue {get; set;} = true;

		public bool ShouldSerializeDocumentNode()
		{
			return ShouldSerializeDocumentNodeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue {get; set;} = true;

		public bool ShouldSerializeModifiedDate()
		{
			return ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeProductIDValue = false;
			this.ShouldSerializeDocumentNodeValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>403b61aca7030bac27d54d9f418ad646</Hash>
</Codenesium>*/