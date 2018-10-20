using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiProductModelProductDescriptionCultureRequestModel : AbstractApiRequestModel
	{
		public ApiProductModelProductDescriptionCultureRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string cultureID,
			DateTime modifiedDate,
			int productDescriptionID)
		{
			this.CultureID = cultureID;
			this.ModifiedDate = modifiedDate;
			this.ProductDescriptionID = productDescriptionID;
		}

		[Required]
		[JsonProperty]
		public string CultureID { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public int ProductDescriptionID { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>d78b38d939fc504762d578b748a823fc</Hash>
</Codenesium>*/