using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>397bcceefb40d6cd26040fe24f9d2889</Hash>
</Codenesium>*/