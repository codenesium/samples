using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>125703aa51f9bec0c3ca3cd5375abefd</Hash>
</Codenesium>*/