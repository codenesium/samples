using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALProductCostHistoryMapper
        {
                ProductCostHistory MapBOToEF(
                        BOProductCostHistory bo);

                BOProductCostHistory MapEFToBO(
                        ProductCostHistory efProductCostHistory);

                List<BOProductCostHistory> MapEFToBO(
                        List<ProductCostHistory> records);
        }
}

/*<Codenesium>
    <Hash>70ed2276d1ed8f9ea376f3cae6871a91</Hash>
</Codenesium>*/