using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiShiftModelMapper
        {
                public virtual ApiShiftResponseModel MapRequestToResponse(
                        int shiftID,
                        ApiShiftRequestModel request)
                {
                        var response = new ApiShiftResponseModel();
                        response.SetProperties(shiftID,
                                               request.EndTime,
                                               request.ModifiedDate,
                                               request.Name,
                                               request.StartTime);
                        return response;
                }

                public virtual ApiShiftRequestModel MapResponseToRequest(
                        ApiShiftResponseModel response)
                {
                        var request = new ApiShiftRequestModel();
                        request.SetProperties(
                                response.EndTime,
                                response.ModifiedDate,
                                response.Name,
                                response.StartTime);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>490136eacec2bdeff0a9e96bd8c65000</Hash>
</Codenesium>*/