using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiProductModelProductDescriptionCultureResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int productModelID,
			string cultureID,
			DateTime modifiedDate,
			int productDescriptionID)
		{
			this.ProductModelID = productModelID;
			this.CultureID = cultureID;
			this.ModifiedDate = modifiedDate;
			this.ProductDescriptionID = productDescriptionID;
		}

		[JsonProperty]
		public string CultureID { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public int ProductDescriptionID { get; private set; }

		[JsonProperty]
		public int ProductModelID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a1843d328246223c4003675a62dc5214</Hash>
</Codenesium>*/