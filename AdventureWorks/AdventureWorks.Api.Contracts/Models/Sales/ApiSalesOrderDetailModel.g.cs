using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiSalesOrderDetailModel: AbstractModel
	{
		public ApiSalesOrderDetailModel() : base()
		{}

		public ApiSalesOrderDetailModel(
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
			this.LineTotal = lineTotal.ToDecimal();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.OrderQty = orderQty;
			this.ProductID = productID.ToInt();
			this.Rowguid = rowguid.ToGuid();
			this.SalesOrderDetailID = salesOrderDetailID.ToInt();
			this.SpecialOfferID = specialOfferID.ToInt();
			this.UnitPrice = unitPrice.ToDecimal();
			this.UnitPriceDiscount = unitPriceDiscount.ToDecimal();
		}

		private string carrierTrackingNumber;

		public string CarrierTrackingNumber
		{
			get
			{
				return this.carrierTrackingNumber.IsEmptyOrZeroOrNull() ? null : this.carrierTrackingNumber;
			}

			set
			{
				this.carrierTrackingNumber = value;
			}
		}

		private decimal lineTotal;

		[Required]
		public decimal LineTotal
		{
			get
			{
				return this.lineTotal;
			}

			set
			{
				this.lineTotal = value;
			}
		}

		private DateTime modifiedDate;

		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return this.modifiedDate;
			}

			set
			{
				this.modifiedDate = value;
			}
		}

		private short orderQty;

		[Required]
		public short OrderQty
		{
			get
			{
				return this.orderQty;
			}

			set
			{
				this.orderQty = value;
			}
		}

		private int productID;

		[Required]
		public int ProductID
		{
			get
			{
				return this.productID;
			}

			set
			{
				this.productID = value;
			}
		}

		private Guid rowguid;

		[Required]
		public Guid Rowguid
		{
			get
			{
				return this.rowguid;
			}

			set
			{
				this.rowguid = value;
			}
		}

		private int salesOrderDetailID;

		[Required]
		public int SalesOrderDetailID
		{
			get
			{
				return this.salesOrderDetailID;
			}

			set
			{
				this.salesOrderDetailID = value;
			}
		}

		private int specialOfferID;

		[Required]
		public int SpecialOfferID
		{
			get
			{
				return this.specialOfferID;
			}

			set
			{
				this.specialOfferID = value;
			}
		}

		private decimal unitPrice;

		[Required]
		public decimal UnitPrice
		{
			get
			{
				return this.unitPrice;
			}

			set
			{
				this.unitPrice = value;
			}
		}

		private decimal unitPriceDiscount;

		[Required]
		public decimal UnitPriceDiscount
		{
			get
			{
				return this.unitPriceDiscount;
			}

			set
			{
				this.unitPriceDiscount = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>744350a9a3686a1d9a048921d3e12eb4</Hash>
</Codenesium>*/