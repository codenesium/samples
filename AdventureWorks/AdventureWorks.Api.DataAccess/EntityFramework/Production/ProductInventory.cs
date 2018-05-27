using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductInventory", Schema="Production")]
	public partial class ProductInventory: AbstractEntityFrameworkDTO
	{
		public ProductInventory()
		{}

		public void SetProperties(
			int productID,
			int bin,
			short locationID,
			DateTime modifiedDate,
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
		public int Bin { get; set; }

		[Column("LocationID", TypeName="smallint")]
		public short LocationID { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Key]
		[Column("ProductID", TypeName="int")]
		public int ProductID { get; set; }

		[Column("Quantity", TypeName="smallint")]
		public short Quantity { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }

		[Column("Shelf", TypeName="nvarchar(10)")]
		public string Shelf { get; set; }
	}
}

/*<Codenesium>
    <Hash>4e91141ebaf45a1b610b687712d7b5cb</Hash>
</Codenesium>*/