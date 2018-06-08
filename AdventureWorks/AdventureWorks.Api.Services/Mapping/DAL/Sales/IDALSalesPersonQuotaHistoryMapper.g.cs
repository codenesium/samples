using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALSalesPersonQuotaHistoryMapper
        {
                SalesPersonQuotaHistory MapBOToEF(
                        BOSalesPersonQuotaHistory bo);

                BOSalesPersonQuotaHistory MapEFToBO(
                        SalesPersonQuotaHistory efSalesPersonQuotaHistory);

                List<BOSalesPersonQuotaHistory> MapEFToBO(
                        List<SalesPersonQuotaHistory> records);
        }
}

/*<Codenesium>
    <Hash>d3b414ee4e55241968c7521e37397c72</Hash>
</Codenesium>*/