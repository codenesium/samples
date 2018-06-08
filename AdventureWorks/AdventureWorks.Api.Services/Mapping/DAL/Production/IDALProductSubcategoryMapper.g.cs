using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALProductSubcategoryMapper
        {
                ProductSubcategory MapBOToEF(
                        BOProductSubcategory bo);

                BOProductSubcategory MapEFToBO(
                        ProductSubcategory efProductSubcategory);

                List<BOProductSubcategory> MapEFToBO(
                        List<ProductSubcategory> records);
        }
}

/*<Codenesium>
    <Hash>d9e74edb2856db1ee78ccaed39a7b4d4</Hash>
</Codenesium>*/