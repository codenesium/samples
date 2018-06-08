using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>ec345649ae457b88360a890ecfb29ea5</Hash>
</Codenesium>*/