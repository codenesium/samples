using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiSalesPersonQuotaHistoryModelMapper
        {
                ApiSalesPersonQuotaHistoryResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiSalesPersonQuotaHistoryRequestModel request);

                ApiSalesPersonQuotaHistoryRequestModel MapResponseToRequest(
                        ApiSalesPersonQuotaHistoryResponseModel response);
        }
}

/*<Codenesium>
    <Hash>b7efb66ee0e45cb705f627144c2d4654</Hash>
</Codenesium>*/