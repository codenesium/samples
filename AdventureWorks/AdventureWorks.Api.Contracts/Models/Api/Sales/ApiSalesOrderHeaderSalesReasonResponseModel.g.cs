using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiSalesOrderHeaderSalesReasonResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int salesOrderID,
			DateTime modifiedDate,
			int salesReasonID)
		{
			this.SalesOrderID = salesOrderID;
			this.ModifiedDate = modifiedDate;
			this.SalesReasonID = salesReasonID;

			this.SalesOrderIDEntity = nameof(ApiResponse.SalesOrderHeaders);
			this.SalesReasonIDEntity = nameof(ApiResponse.SalesReasons);
		}

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public int SalesOrderID { get; private set; }

		[JsonProperty]
		public string SalesOrderIDEntity { get; set; }

		[JsonProperty]
		public int SalesReasonID { get; private set; }

		[JsonProperty]
		public string SalesReasonIDEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>2e7ca283d131b46d720f69ef001d7f5e</Hash>
</Codenesium>*/