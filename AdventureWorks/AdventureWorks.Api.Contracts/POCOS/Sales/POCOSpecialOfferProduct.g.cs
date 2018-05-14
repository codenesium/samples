using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOSpecialOfferProduct
	{
		public POCOSpecialOfferProduct()
		{}

		public POCOSpecialOfferProduct(
			DateTime modifiedDate,
			int productID,
			Guid rowguid,
			int specialOfferID)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ProductID = productID.ToInt();
			this.Rowguid = rowguid.ToGuid();

			this.SpecialOfferID = new ReferenceEntity<int>(specialOfferID,
			                                               nameof(ApiResponse.SpecialOffers));
		}

		public DateTime ModifiedDate { get; set; }
		public int ProductID { get; set; }
		public Guid Rowguid { get; set; }
		public ReferenceEntity<int> SpecialOfferID { get; set; }

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

		[JsonIgnore]
		public bool ShouldSerializeRowguidValue { get; set; } = true;

		public bool ShouldSerializeRowguid()
		{
			return this.ShouldSerializeRowguidValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSpecialOfferIDValue { get; set; } = true;

		public bool ShouldSerializeSpecialOfferID()
		{
			return this.ShouldSerializeSpecialOfferIDValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeProductIDValue = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeSpecialOfferIDValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>413a153cefecb50c3f10b07ccb78ca42</Hash>
</Codenesium>*/