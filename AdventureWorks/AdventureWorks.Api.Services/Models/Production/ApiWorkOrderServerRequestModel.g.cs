using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiWorkOrderServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiWorkOrderServerRequestModel()
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
		public DateTime DueDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public DateTime? EndDate { get; private set; } = null;

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

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
		public DateTime StartDate { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public int StockedQty { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>84f4fe848a2c948d94c635df8c856289</Hash>
</Codenesium>*/