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
		public DateTime ModifiedDate { get; private set; }

		[Required]
		[JsonProperty]
		public bool Primary { get; private set; }

		[Required]
		[JsonProperty]
		public int ProductPhotoID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>227981dca391bb8f0734e14810c0be81</Hash>
</Codenesium>*/