using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiProductProductPhotoResponseModel: AbstractApiResponseModel
	{
		public ApiProductProductPhotoResponseModel() : base()
		{}

		public void SetProperties(
			DateTime modifiedDate,
			bool primary,
			int productID,
			int productPhotoID)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Primary = primary.ToBoolean();
			this.ProductID = productID.ToInt();
			this.ProductPhotoID = productPhotoID.ToInt();
		}

		public DateTime ModifiedDate { get; set; }
		public bool Primary { get; set; }
		public int ProductID { get; set; }
		public int ProductPhotoID { get; set; }

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
    <Hash>17ae8981032a90b04e6f7a1e1bd3c86d</Hash>
</Codenesium>*/