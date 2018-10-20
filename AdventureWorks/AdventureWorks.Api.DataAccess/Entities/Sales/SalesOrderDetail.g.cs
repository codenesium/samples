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
			string carrierTrackingNumber,
			decimal lineTotal,
			DateTime modifiedDate,
			short orderQty,
			int productID,
			Guid rowguid,
			int salesOrderDetailID,
			int salesOrderID,
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
			this.SalesOrderID = salesOrderID;
			this.SpecialOfferID = specialOfferID;
			this.UnitPrice = unitPrice;
			this.UnitPriceDiscount = unitPriceDiscount;
		}

		[MaxLength(25)]
		[Column("CarrierTrackingNumber")]
		public string CarrierTrackingNumber { get; private set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("LineTotal")]
		public decimal LineTotal { get; private set; }

		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; private set; }

		[Column("OrderQty")]
		public short OrderQty { get; private set; }

		[Column("ProductID")]
		public int ProductID { get; private set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("rowguid")]
		public Guid Rowguid { get; private set; }

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("SalesOrderDetailID")]
		public int SalesOrderDetailID { get; private set; }

		[Key]
		[Column("SalesOrderID")]
		public int SalesOrderID { get; private set; }

		[Column("SpecialOfferID")]
		public int SpecialOfferID { get; private set; }

		[Column("UnitPrice")]
		public decimal UnitPrice { get; private set; }

		[Column("UnitPriceDiscount")]
		public decimal UnitPriceDiscount { get; private set; }

		[ForeignKey("SalesOrderID")]
		public virtual SalesOrderHeader SalesOrderHeaderNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>761ed30eeb3e736826a0561ba5995d29</Hash>
</Codenesium>*/