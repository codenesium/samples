using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOProductDocument
	{
		public POCOProductDocument()
		{}

		public POCOProductDocument(
			Guid documentNode,
			DateTime modifiedDate,
			int productID)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();

			this.DocumentNode = new ReferenceEntity<Guid>(documentNode,
			                                              nameof(ApiResponse.Documents));
			this.ProductID = new ReferenceEntity<int>(productID,
			                                          nameof(ApiResponse.Products));
		}

		public ReferenceEntity<Guid> DocumentNode { get; set; }
		public DateTime ModifiedDate { get; set; }
		public ReferenceEntity<int> ProductID { get; set; }

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
    <Hash>d36b6ba71415d0ef272d91e23abdb493</Hash>
</Codenesium>*/