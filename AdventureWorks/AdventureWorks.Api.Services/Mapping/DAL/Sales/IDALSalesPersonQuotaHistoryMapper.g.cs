using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>79b79b8b379addded624e36e962bffaa</Hash>
</Codenesium>*/