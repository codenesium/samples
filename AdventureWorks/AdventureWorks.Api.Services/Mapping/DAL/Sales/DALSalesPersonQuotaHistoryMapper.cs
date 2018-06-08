using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALSalesPersonQuotaHistoryMapper: DALAbstractSalesPersonQuotaHistoryMapper, IDALSalesPersonQuotaHistoryMapper
        {
                public DALSalesPersonQuotaHistoryMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>396851aa6c21b197d5a1d0a54d01eb59</Hash>
</Codenesium>*/