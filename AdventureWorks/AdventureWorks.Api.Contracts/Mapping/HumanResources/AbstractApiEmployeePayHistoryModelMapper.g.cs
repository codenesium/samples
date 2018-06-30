using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiEmployeePayHistoryModelMapper
        {
                public virtual ApiEmployeePayHistoryResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiEmployeePayHistoryRequestModel request)
                {
                        var response = new ApiEmployeePayHistoryResponseModel();
                        response.SetProperties(businessEntityID,
                                               request.ModifiedDate,
                                               request.PayFrequency,
                                               request.Rate,
                                               request.RateChangeDate);
                        return response;
                }

                public virtual ApiEmployeePayHistoryRequestModel MapResponseToRequest(
                        ApiEmployeePayHistoryResponseModel response)
                {
                        var request = new ApiEmployeePayHistoryRequestModel();
                        request.SetProperties(
                                response.ModifiedDate,
                                response.PayFrequency,
                                response.Rate,
                                response.RateChangeDate);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>8e3356998f075f533a0aeef0db06345f</Hash>
</Codenesium>*/