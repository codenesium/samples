using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOProductProductPhoto
	{
		public POCOProductProductPhoto()
		{}

		public POCOProductProductPhoto(int productID,
		                               int productPhotoID,
		                               bool primary,
		                               DateTime modifiedDate)
		{
			this.ProductID = productID.ToInt();
			this.ProductPhotoID = productPhotoID.ToInt();
			this.Primary = primary;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public int ProductID {get; set;}
		public int ProductPhotoID {get; set;}
		public bool Primary {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeProductIDValue {get; set;} = true;

		public bool ShouldSerializeProductID()
		{
			return ShouldSerializeProductIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductPhotoIDValue {get; set;} = true;

		public bool ShouldSerializeProductPhotoID()
		{
			return ShouldSerializeProductPhotoIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePrimaryValue {get; set;} = true;

		public bool ShouldSerializePrimary()
		{
			return ShouldSerializePrimaryValue;
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
			this.ShouldSerializeProductPhotoIDValue = false;
			this.ShouldSerializePrimaryValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>bb5f92a3b8a37bbd54af1419fb8becd1</Hash>
</Codenesium>*/