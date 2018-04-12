using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class SalesOrderDetailModel
	{
		public SalesOrderDetailModel()
		{}

		public SalesOrderDetailModel(
			int salesOrderDetailID,
			string carrierTrackingNumber,
			short orderQty,
			int productID,
			int specialOfferID,
			decimal unitPrice,
			decimal unitPriceDiscount,
			decimal lineTotal,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.SalesOrderDetailID = salesOrderDetailID.ToInt();
			this.CarrierTrackingNumber = carrierTrackingNumber;
			this.OrderQty = orderQty;
			this.ProductID = productID.ToInt();
			this.SpecialOfferID = specialOfferID.ToInt();
			this.UnitPrice = unitPrice;
			this.UnitPriceDiscount = unitPriceDiscount;
			this.LineTotal = lineTotal.ToDecimal();
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
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
	}
}

/*<Codenesium>
    <Hash>1e52f2f7ea4188ad23225857b64192dd</Hash>
</Codenesium>*/