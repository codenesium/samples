using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiProductProductPhotoServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiProductProductPhotoServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			DateTime modifiedDate,
			bool primary,
			int productPhotoID)
		{
			this.ModifiedDate = modifiedDate;
			this.Primary = primary;
			this.ProductPhotoID = productPhotoID;
		}

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public bool Primary { get; private set; } = default(bool);

		[Required]
		[JsonProperty]
		public int ProductPhotoID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>063f9d43f207906897a4efbcb736970c</Hash>
</Codenesium>*/