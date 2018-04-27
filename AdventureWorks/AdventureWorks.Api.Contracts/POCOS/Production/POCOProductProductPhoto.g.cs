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
			DateTime modifiedDate,
			bool primary,
			int productID,
			int productPhotoID)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Primary = primary.ToBoolean();

			this.ProductID = new ReferenceEntity<int>(productID,
			                                          nameof(ApiResponse.Products));
			this.ProductPhotoID = new ReferenceEntity<int>(productPhotoID,
			                                               nameof(ApiResponse.ProductPhotoes));
		}

		public DateTime ModifiedDate { get; set; }
		public bool Primary { get; set; }
		public ReferenceEntity<int> ProductID { get; set; }
		public ReferenceEntity<int> ProductPhotoID { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePrimaryValue { get; set; } = true;

		public bool ShouldSerializePrimary()
		{
			return this.ShouldSerializePrimaryValue;
		}

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

		public void DisableAllFields()
		{
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializePrimaryValue = false;
			this.ShouldSerializeProductIDValue = false;
			this.ShouldSerializeProductPhotoIDValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>812d003270dafa1422fab488f6aa9672</Hash>
</Codenesium>*/