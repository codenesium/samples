using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractProductInventoryMapper
        {
                public virtual ProductInventory MapBOToEF(
                        BOProductInventory bo)
                {
                        ProductInventory efProductInventory = new ProductInventory();
                        efProductInventory.SetProperties(
                                bo.Bin,
                                bo.LocationID,
                                bo.ModifiedDate,
                                bo.ProductID,
                                bo.Quantity,
                                bo.Rowguid,
                                bo.Shelf);
                        return efProductInventory;
                }

                public virtual BOProductInventory MapEFToBO(
                        ProductInventory ef)
                {
                        var bo = new BOProductInventory();

                        bo.SetProperties(
                                ef.ProductID,
                                ef.Bin,
                                ef.LocationID,
                                ef.ModifiedDate,
                                ef.Quantity,
                                ef.Rowguid,
                                ef.Shelf);
                        return bo;
                }

                public virtual List<BOProductInventory> MapEFToBO(
                        List<ProductInventory> records)
                {
                        List<BOProductInventory> response = new List<BOProductInventory>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>705680216cf89032a4e63909ddae98ef</Hash>
</Codenesium>*/