using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductInventory", Schema="Production")]
	public partial class ProductInventory : AbstractEntity
	{
		public ProductInventory()
		{
		}

		public virtual void SetProperties(
			int bin,
			short locationID,
			DateTime modifiedDate,
			int productID,
			short quantity,
			Guid rowguid,
			string shelf)
		{
			this.Bin = bin;
			this.LocationID = locationID;
			this.ModifiedDate = modifiedDate;
			this.ProductID = productID;
			this.Quantity = quantity;
			this.Rowguid = rowguid;
			this.Shelf = shelf;
		}

		[Column("Bin")]
		public virtual int Bin { get; private set; }

		[Key]
		[Column("LocationID")]
		public virtual short LocationID { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[Key]
		[Column("ProductID")]
		public virtual int ProductID { get; private set; }

		[Column("Quantity")]
		public virtual short Quantity { get; private set; }

		[Column("rowguid")]
		public virtual Guid Rowguid { get; private set; }

		[MaxLength(10)]
		[Column("Shelf")]
		public virtual string Shelf { get; private set; }
	}
}

/*<Codenesium>
    <Hash>cad140ab9e7df1866d89891feb16ac6a</Hash>
</Codenesium>*/