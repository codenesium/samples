using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiWorkOrderRequestModel : AbstractApiRequestModel
	{
		public ApiWorkOrderRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			DateTime dueDate,
			DateTime? endDate,
			DateTime modifiedDate,
			int orderQty,
			int productID,
			short scrappedQty,
			short? scrapReasonID,
			DateTime startDate,
			int stockedQty)
		{
			this.DueDate = dueDate;
			this.EndDate = endDate;
			this.ModifiedDate = modifiedDate;
			this.OrderQty = orderQty;
			this.ProductID = productID;
			this.ScrappedQty = scrappedQty;
			this.ScrapReasonID = scrapReasonID;
			this.StartDate = startDate;
			this.StockedQty = stockedQty;
		}

		[Required]
		[JsonProperty]
		public DateTime DueDate { get; private set; } = default(DateTime);

		[JsonProperty]
		public DateTime? EndDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public int OrderQty { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public int ProductID { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public short ScrappedQty { get; private set; } = default(short);

		[JsonProperty]
		public short? ScrapReasonID { get; private set; } = default(short);

		[Required]
		[JsonProperty]
		public DateTime StartDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public int StockedQty { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>232c69e858c755d8764b61fc36ce7e2c</Hash>
</Codenesium>*/