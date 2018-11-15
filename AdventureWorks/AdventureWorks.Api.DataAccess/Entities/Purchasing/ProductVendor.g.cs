using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductVendor", Schema="Purchasing")]
	public partial class ProductVendor : AbstractEntity
	{
		public ProductVendor()
		{
		}

		public virtual void SetProperties(
			int averageLeadTime,
			int businessEntityID,
			decimal? lastReceiptCost,
			DateTime? lastReceiptDate,
			int maxOrderQty,
			int minOrderQty,
			DateTime modifiedDate,
			int? onOrderQty,
			int productID,
			decimal standardPrice,
			string unitMeasureCode)
		{
			this.AverageLeadTime = averageLeadTime;
			this.BusinessEntityID = businessEntityID;
			this.LastReceiptCost = lastReceiptCost;
			this.LastReceiptDate = lastReceiptDate;
			this.MaxOrderQty = maxOrderQty;
			this.MinOrderQty = minOrderQty;
			this.ModifiedDate = modifiedDate;
			this.OnOrderQty = onOrderQty;
			this.ProductID = productID;
			this.StandardPrice = standardPrice;
			this.UnitMeasureCode = unitMeasureCode;
		}

		[Column("AverageLeadTime")]
		public virtual int AverageLeadTime { get; private set; }

		[Key]
		[Column("BusinessEntityID")]
		public virtual int BusinessEntityID { get; private set; }

		[Column("LastReceiptCost")]
		public virtual decimal? LastReceiptCost { get; private set; }

		[Column("LastReceiptDate")]
		public virtual DateTime? LastReceiptDate { get; private set; }

		[Column("MaxOrderQty")]
		public virtual int MaxOrderQty { get; private set; }

		[Column("MinOrderQty")]
		public virtual int MinOrderQty { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[Column("OnOrderQty")]
		public virtual int? OnOrderQty { get; private set; }

		[Key]
		[Column("ProductID")]
		public virtual int ProductID { get; private set; }

		[Column("StandardPrice")]
		public virtual decimal StandardPrice { get; private set; }

		[MaxLength(3)]
		[Column("UnitMeasureCode")]
		public virtual string UnitMeasureCode { get; private set; }
	}
}

/*<Codenesium>
    <Hash>18e7f92afb787cc35548ea6d8550fede</Hash>
</Codenesium>*/