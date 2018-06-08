using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALProductCategoryMapper
        {
                ProductCategory MapBOToEF(
                        BOProductCategory bo);

                BOProductCategory MapEFToBO(
                        ProductCategory efProductCategory);

                List<BOProductCategory> MapEFToBO(
                        List<ProductCategory> records);
        }
}

/*<Codenesium>
    <Hash>d93c62ae83fe5770e616c20e90454bd7</Hash>
</Codenesium>*/