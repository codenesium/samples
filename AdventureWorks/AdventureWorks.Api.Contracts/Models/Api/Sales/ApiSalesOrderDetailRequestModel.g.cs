using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiSalesOrderDetailRequestModel : AbstractApiRequestModel
	{
		public ApiSalesOrderDetailRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string carrierTrackingNumber,
			decimal lineTotal,
			DateTime modifiedDate,
			short orderQty,
			int productID,
			Guid rowguid,
			int salesOrderDetailID,
			int specialOfferID,
			decimal unitPrice,
			decimal unitPriceDiscount)
		{
			this.CarrierTrackingNumber = carrierTrackingNumber;
			this.LineTotal = lineTotal;
			this.ModifiedDate = modifiedDate;
			this.OrderQty = orderQty;
			this.ProductID = productID;
			this.Rowguid = rowguid;
			this.SalesOrderDetailID = salesOrderDetailID;
			this.SpecialOfferID = specialOfferID;
			this.UnitPrice = unitPrice;
			this.UnitPriceDiscount = unitPriceDiscount;
		}

		[JsonProperty]
		public string CarrierTrackingNumber { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public decimal LineTotal { get; private set; } = default(decimal);

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public short OrderQty { get; private set; } = default(short);

		[Required]
		[JsonProperty]
		public int ProductID { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public Guid Rowguid { get; private set; } = default(Guid);

		[Required]
		[JsonProperty]
		public int SalesOrderDetailID { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public int SpecialOfferID { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public decimal UnitPrice { get; private set; } = default(decimal);

		[Required]
		[JsonProperty]
		public decimal UnitPriceDiscount { get; private set; } = default(decimal);
	}
}

/*<Codenesium>
    <Hash>527ed618a2dfae02c6dc9e2eb85abe6b</Hash>
</Codenesium>*/