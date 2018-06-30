using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiSalesPersonQuotaHistoryModelMapper
        {
                public virtual ApiSalesPersonQuotaHistoryResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiSalesPersonQuotaHistoryRequestModel request)
                {
                        var response = new ApiSalesPersonQuotaHistoryResponseModel();
                        response.SetProperties(businessEntityID,
                                               request.ModifiedDate,
                                               request.QuotaDate,
                                               request.Rowguid,
                                               request.SalesQuota);
                        return response;
                }

                public virtual ApiSalesPersonQuotaHistoryRequestModel MapResponseToRequest(
                        ApiSalesPersonQuotaHistoryResponseModel response)
                {
                        var request = new ApiSalesPersonQuotaHistoryRequestModel();
                        request.SetProperties(
                                response.ModifiedDate,
                                response.QuotaDate,
                                response.Rowguid,
                                response.SalesQuota);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>e56e8e8ef78269cb9c19996eb3ff27b7</Hash>
</Codenesium>*/