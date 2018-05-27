using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOProductInventory: AbstractDTO
	{
		public DTOProductInventory() : base()
		{}

		public void SetProperties(int productID,
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

		public int Bin { get; set; }
		public short LocationID { get; set; }
		public DateTime ModifiedDate { get; set; }
		public int ProductID { get; set; }
		public short Quantity { get; set; }
		public Guid Rowguid { get; set; }
		public string Shelf { get; set; }
	}
}

/*<Codenesium>
    <Hash>4f793f3990027d974bd540b539a48aa9</Hash>
</Codenesium>*/