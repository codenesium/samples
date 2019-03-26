using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiProductProductPhotoClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiProductProductPhotoClientRequestModel()
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

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public bool Primary { get; private set; } = default(bool);

		[JsonProperty]
		public int ProductPhotoID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a47b046bcbe54bc2028bfc414bd81039</Hash>
</Codenesium>*/