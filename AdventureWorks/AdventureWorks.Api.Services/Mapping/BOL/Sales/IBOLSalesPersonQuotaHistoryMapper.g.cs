using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>d46e1975f0c065b1ca4323e66c441aac</Hash>
</Codenesium>*/