using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOProductInventory: AbstractBusinessObject
        {
                public BOProductInventory() : base()
                {
                }

                public void SetProperties(int productID,
                                          int bin,
                                          short locationID,
                                          DateTime modifiedDate,
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
    <Hash>02993c5c7998166862434575a3682edd</Hash>
</Codenesium>*/