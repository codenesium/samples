using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiWorkOrderClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiWorkOrderClientRequestModel()
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

		[JsonProperty]
		public DateTime DueDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public DateTime? EndDate { get; private set; } = null;

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public int OrderQty { get; private set; } = default(int);

		[JsonProperty]
		public int ProductID { get; private set; }

		[JsonProperty]
		public short ScrappedQty { get; private set; } = default(short);

		[JsonProperty]
		public short? ScrapReasonID { get; private set; }

		[JsonProperty]
		public DateTime StartDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public int StockedQty { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>8c0ff59bacab2106b087349e5b8c95ba</Hash>
</Codenesium>*/