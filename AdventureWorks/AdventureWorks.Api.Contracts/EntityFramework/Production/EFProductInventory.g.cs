using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("ProductInventory", Schema="Production")]
	public partial class EFProductInventory
	{
		public EFProductInventory()
		{}

		public void SetProperties(int productID,
		                          short locationID,
		                          string shelf,
		                          int bin,
		                          short quantity,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			this.ProductID = productID.ToInt();
			this.LocationID = locationID;
			this.Shelf = shelf;
			this.Bin = bin;
			this.Quantity = quantity;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ProductID", TypeName="int")]
		public int ProductID {get; set;}

		[Column("LocationID", TypeName="smallint")]
		public short LocationID {get; set;}

		[Column("Shelf", TypeName="nvarchar(10)")]
		public string Shelf {get; set;}

		[Column("Bin", TypeName="tinyint")]
		public int Bin {get; set;}

		[Column("Quantity", TypeName="smallint")]
		public short Quantity {get; set;}

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		public virtual EFProduct Product { get; set; }

		public virtual EFLocation Location { get; set; }
	}
}

/*<Codenesium>
    <Hash>fc3b0dfba5d760ac0c3d17dead63e81e</Hash>
</Codenesium>*/