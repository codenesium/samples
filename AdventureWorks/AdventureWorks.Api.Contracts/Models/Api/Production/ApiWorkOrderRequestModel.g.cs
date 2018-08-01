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
		public DateTime DueDate { get; private set; }

		[JsonProperty]
		public DateTime? EndDate { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[Required]
		[JsonProperty]
		public int OrderQty { get; private set; }

		[Required]
		[JsonProperty]
		public int ProductID { get; private set; }

		[Required]
		[JsonProperty]
		public short ScrappedQty { get; private set; }

		[JsonProperty]
		public short? ScrapReasonID { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime StartDate { get; private set; }

		[Required]
		[JsonProperty]
		public int StockedQty { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c55930e1fa33d4e460e5567ec2dd9dfb</Hash>
</Codenesium>*/