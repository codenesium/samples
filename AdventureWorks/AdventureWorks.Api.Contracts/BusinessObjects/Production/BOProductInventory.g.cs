using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class BOProductInventory: AbstractBusinessObject
	{
		public BOProductInventory() : base()
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

		public int Bin { get; private set; }
		public short LocationID { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public int ProductID { get; private set; }
		public short Quantity { get; private set; }
		public Guid Rowguid { get; private set; }
		public string Shelf { get; private set; }
	}
}

/*<Codenesium>
    <Hash>b54d84f35bafd07cf661dcc417d8945e</Hash>
</Codenesium>*/