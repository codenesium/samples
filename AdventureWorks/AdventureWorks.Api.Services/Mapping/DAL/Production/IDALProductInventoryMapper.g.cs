using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALProductInventoryMapper
        {
                ProductInventory MapBOToEF(
                        BOProductInventory bo);

                BOProductInventory MapEFToBO(
                        ProductInventory efProductInventory);

                List<BOProductInventory> MapEFToBO(
                        List<ProductInventory> records);
        }
}

/*<Codenesium>
    <Hash>b4d3a3f73bb2b30f2b9a8445f3fee5f8</Hash>
</Codenesium>*/