using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALProductListPriceHistoryMapper
        {
                ProductListPriceHistory MapBOToEF(
                        BOProductListPriceHistory bo);

                BOProductListPriceHistory MapEFToBO(
                        ProductListPriceHistory efProductListPriceHistory);

                List<BOProductListPriceHistory> MapEFToBO(
                        List<ProductListPriceHistory> records);
        }
}

/*<Codenesium>
    <Hash>90265aabee40077f33d1cedced2fc28b</Hash>
</Codenesium>*/