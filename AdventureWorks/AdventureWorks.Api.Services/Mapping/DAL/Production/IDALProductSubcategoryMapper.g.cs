using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>02f9842d0457cca2a1bf04ce8f71f418</Hash>
</Codenesium>*/