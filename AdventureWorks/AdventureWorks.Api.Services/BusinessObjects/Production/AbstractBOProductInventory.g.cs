using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOProductInventory : AbstractBusinessObject
        {
                public AbstractBOProductInventory()
                        : base()
                {
                }

                public virtual void SetProperties(int productID,
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
    <Hash>0b2aa5bb8b56a43a6061b540359dd11a</Hash>
</Codenesium>*/