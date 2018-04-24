using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductInventory", Schema="Production")]
	public partial class EFProductInventory: AbstractEntityFrameworkPOCO
	{
		public EFProductInventory()
		{}

		public void SetProperties(
			int productID,
			short locationID,
			string shelf,
			int bin,
			short quantity,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.ProductID = productID.ToInt();
			this.LocationID = locationID;
			this.Shelf = shelf.ToString();
			this.Bin = bin.ToInt();
			this.Quantity = quantity;
			this.Rowguid = rowguid.ToGuid();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[Column("ProductID", TypeName="int")]
		public int ProductID { get; set; }

		[Column("LocationID", TypeName="smallint")]
		public short LocationID { get; set; }

		[Column("Shelf", TypeName="nvarchar(10)")]
		public string Shelf { get; set; }

		[Column("Bin", TypeName="tinyint")]
		public int Bin { get; set; }

		[Column("Quantity", TypeName="smallint")]
		public short Quantity { get; set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[ForeignKey("ProductID")]
		public virtual EFProduct Product { get; set; }

		[ForeignKey("LocationID")]
		public virtual EFLocation Location { get; set; }
	}
}

/*<Codenesium>
    <Hash>57fb92f3c4d3dce7edaeaeda6587e450</Hash>
</Codenesium>*/