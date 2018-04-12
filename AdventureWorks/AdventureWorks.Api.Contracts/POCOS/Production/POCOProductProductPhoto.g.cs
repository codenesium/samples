using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOProductProductPhoto
	{
		public POCOProductProductPhoto()
		{}

		public POCOProductProductPhoto(
			int productID,
			int productPhotoID,
			bool primary,
			DateTime modifiedDate)
		{
			this.Primary = primary;
			this.ModifiedDate = modifiedDate.ToDateTime();

			this.ProductID = new ReferenceEntity<int>(productID,
			                                          "Product");
			this.ProductPhotoID = new ReferenceEntity<int>(productPhotoID,
			                                               "ProductPhoto");
		}

		public ReferenceEntity<int> ProductID { get; set; }
		public ReferenceEntity<int> ProductPhotoID { get; set; }
		public bool Primary { get; set; }
		public DateTime ModifiedDate { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeProductIDValue { get; set; } = true;

		public bool ShouldSerializeProductID()
		{
			return this.ShouldSerializeProductIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductPhotoIDValue { get; set; } = true;

		public bool ShouldSerializeProductPhotoID()
		{
			return this.ShouldSerializeProductPhotoIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePrimaryValue { get; set; } = true;

		public bool ShouldSerializePrimary()
		{
			return this.ShouldSerializePrimaryValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeProductIDValue = false;
			this.ShouldSerializeProductPhotoIDValue = false;
			this.ShouldSerializePrimaryValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>d6e2e22b145464876886bf3c4191fa25</Hash>
</Codenesium>*/