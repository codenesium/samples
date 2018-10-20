using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiProductProductPhotoRequestModel : AbstractApiRequestModel
	{
		public ApiProductProductPhotoRequestModel()
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
		public DateTime ModifiedDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public bool Primary { get; private set; } = default(bool);

		[Required]
		[JsonProperty]
		public int ProductPhotoID { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>26e9d5b50d5c98c6169ee9585c0580b2</Hash>
</Codenesium>*/