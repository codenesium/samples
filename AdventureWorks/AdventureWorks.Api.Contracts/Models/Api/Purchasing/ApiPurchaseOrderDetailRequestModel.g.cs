using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiPurchaseOrderDetailRequestModel : AbstractApiRequestModel
	{
		public ApiPurchaseOrderDetailRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			DateTime dueDate,
			decimal lineTotal,
			DateTime modifiedDate,
			short orderQty,
			int productID,
			int purchaseOrderDetailID,
			double receivedQty,
			double rejectedQty,
			double stockedQty,
			decimal unitPrice)
		{
			this.DueDate = dueDate;
			this.LineTotal = lineTotal;
			this.ModifiedDate = modifiedDate;
			this.OrderQty = orderQty;
			this.ProductID = productID;
			this.PurchaseOrderDetailID = purchaseOrderDetailID;
			this.ReceivedQty = receivedQty;
			this.RejectedQty = rejectedQty;
			this.StockedQty = stockedQty;
			this.UnitPrice = unitPrice;
		}

		[Required]
		[JsonProperty]
		public DateTime DueDate { get; private set; }

		[Required]
		[JsonProperty]
		public decimal LineTotal { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[Required]
		[JsonProperty]
		public short OrderQty { get; private set; }

		[Required]
		[JsonProperty]
		public int ProductID { get; private set; }

		[Required]
		[JsonProperty]
		public int PurchaseOrderDetailID { get; private set; }

		[Required]
		[JsonProperty]
		public double ReceivedQty { get; private set; }

		[Required]
		[JsonProperty]
		public double RejectedQty { get; private set; }

		[Required]
		[JsonProperty]
		public double StockedQty { get; private set; }

		[Required]
		[JsonProperty]
		public decimal UnitPrice { get; private set; }
	}
}

/*<Codenesium>
    <Hash>9e9370e50f0b506842a21c14f57db243</Hash>
</Codenesium>*/