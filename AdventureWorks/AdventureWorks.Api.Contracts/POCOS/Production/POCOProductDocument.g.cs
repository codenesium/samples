using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOProductDocument: AbstractPOCO
	{
		public POCOProductDocument() : base()
		{}

		public POCOProductDocument(
			Guid documentNode,
			DateTime modifiedDate,
			int productID)
		{
			this.DocumentNode = documentNode.ToGuid();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ProductID = productID.ToInt();
		}

		public Guid DocumentNode { get; set; }
		public DateTime ModifiedDate { get; set; }
		public int ProductID { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeDocumentNodeValue { get; set; } = true;

		public bool ShouldSerializeDocumentNode()
		{
			return this.ShouldSerializeDocumentNodeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductIDValue { get; set; } = true;

		public bool ShouldSerializeProductID()
		{
			return this.ShouldSerializeProductIDValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeDocumentNodeValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeProductIDValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>f7c53482dd3233b47733f2bdb54d381f</Hash>
</Codenesium>*/