using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLSalesPersonQuotaHistoryMapper
        {
                BOSalesPersonQuotaHistory MapModelToBO(
                        int businessEntityID,
                        ApiSalesPersonQuotaHistoryRequestModel model);

                ApiSalesPersonQuotaHistoryResponseModel MapBOToModel(
                        BOSalesPersonQuotaHistory boSalesPersonQuotaHistory);

                List<ApiSalesPersonQuotaHistoryResponseModel> MapBOToModel(
                        List<BOSalesPersonQuotaHistory> items);
        }
}

/*<Codenesium>
    <Hash>65561faa949489fc918f730c4e1f3406</Hash>
</Codenesium>*/