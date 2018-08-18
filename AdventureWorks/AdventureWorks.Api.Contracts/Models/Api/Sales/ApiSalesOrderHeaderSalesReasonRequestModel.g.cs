using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiSalesOrderHeaderSalesReasonRequestModel : AbstractApiRequestModel
	{
		public ApiSalesOrderHeaderSalesReasonRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			DateTime modifiedDate,
			int salesReasonID)
		{
			this.ModifiedDate = modifiedDate;
			this.SalesReasonID = salesReasonID;
		}

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[Required]
		[JsonProperty]
		public int SalesReasonID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>82c1a86fbbff81cb7cc4662f67e10257</Hash>
</Codenesium>*/