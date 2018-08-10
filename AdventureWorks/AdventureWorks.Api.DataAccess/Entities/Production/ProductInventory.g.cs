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
		public int Bin { get; private set; }

		[Column("LocationID")]
		public short LocationID { get; private set; }

		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; private set; }

		[Key]
		[Column("ProductID")]
		public int ProductID { get; private set; }

		[Column("Quantity")]
		public short Quantity { get; private set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("rowguid")]
		public Guid Rowguid { get; private set; }

		[Column("Shelf")]
		public string Shelf { get; private set; }
	}
}

/*<Codenesium>
    <Hash>6267f79997a4c363f922d1458ca93eb0</Hash>
</Codenesium>*/