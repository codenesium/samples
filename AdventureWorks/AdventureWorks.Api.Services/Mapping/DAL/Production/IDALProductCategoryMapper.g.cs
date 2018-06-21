using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>e5dd5058fa64551edae682dc9441c266</Hash>
</Codenesium>*/