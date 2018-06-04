using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductInventory", Schema="Production")]
	public partial class ProductInventory: AbstractEntity
	{
		public ProductInventory()
		{}

		public void SetProperties(
			int bin,
			short locationID,
			DateTime modifiedDate,
			int productID,
			short quantity,
			Guid rowguid,
			string shelf)
		{
			this.Bin = bin.ToInt();
			this.LocationID = locationID;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ProductID = productID.ToInt();
			this.Quantity = quantity;
			this.Rowguid = rowguid.ToGuid();
			this.Shelf = shelf;
		}

		[Column("Bin", TypeName="tinyint")]
		public int Bin { get; private set; }

		[Column("LocationID", TypeName="smallint")]
		public short LocationID { get; private set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; private set; }

		[Key]
		[Column("ProductID", TypeName="int")]
		public int ProductID { get; private set; }

		[Column("Quantity", TypeName="smallint")]
		public short Quantity { get; private set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; private set; }

		[Column("Shelf", TypeName="nvarchar(10)")]
		public string Shelf { get; private set; }
	}
}

/*<Codenesium>
    <Hash>bbc42e9fa267a7fcc4ed153b24cc1de0</Hash>
</Codenesium>*/