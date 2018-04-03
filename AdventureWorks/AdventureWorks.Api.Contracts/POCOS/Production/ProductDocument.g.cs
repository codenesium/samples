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
			this.ProductID = productID.ToInt();
			this.DocumentNode = documentNode;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public int ProductID {get; set;}
		public Guid DocumentNode {get; set;}
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
    <Hash>b94beb9e567cff7a22b5ace34322cdbd</Hash>
</Codenesium>*/