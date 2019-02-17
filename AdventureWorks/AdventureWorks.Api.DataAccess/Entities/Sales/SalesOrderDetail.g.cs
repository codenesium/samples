using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("SalesOrderDetail", Schema="Sales")]
	public partial class SalesOrderDetail : AbstractEntity
	{
		public SalesOrderDetail()
		{
		}

		public virtual void SetProperties(
			int salesOrderID,
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
			this.SalesOrderID = salesOrderID;
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

		[MaxLength(25)]
		[Column("CarrierTrackingNumber")]
		public virtual string CarrierTrackingNumber { get; private set; }

		[Column("LineTotal")]
		public virtual decimal LineTotal { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[Column("OrderQty")]
		public virtual short OrderQty { get; private set; }

		[Column("ProductID")]
		public virtual int ProductID { get; private set; }

		[Column("rowguid")]
		public virtual Guid Rowguid { get; private set; }

		[Key]
		[Column("SalesOrderDetailID")]
		public virtual int SalesOrderDetailID { get; private set; }

		[Key]
		[Column("SalesOrderID")]
		public virtual int SalesOrderID { get; private set; }

		[Column("SpecialOfferID")]
		public virtual int SpecialOfferID { get; private set; }

		[Column("UnitPrice")]
		public virtual decimal UnitPrice { get; private set; }

		[Column("UnitPriceDiscount")]
		public virtual decimal UnitPriceDiscount { get; private set; }

		[ForeignKey("SalesOrderID")]
		public virtual SalesOrderHeader SalesOrderIDNavigation { get; private set; }

		public void SetSalesOrderIDNavigation(SalesOrderHeader item)
		{
			this.SalesOrderIDNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>a6e96c4a08ee896dddfe6df6b6a047cd</Hash>
</Codenesium>*/