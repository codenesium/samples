using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiErrorLogModelMapper
        {
                public virtual ApiErrorLogResponseModel MapRequestToResponse(
                        int errorLogID,
                        ApiErrorLogRequestModel request)
                {
                        var response = new ApiErrorLogResponseModel();
                        response.SetProperties(errorLogID,
                                               request.ErrorLine,
                                               request.ErrorMessage,
                                               request.ErrorNumber,
                                               request.ErrorProcedure,
                                               request.ErrorSeverity,
                                               request.ErrorState,
                                               request.ErrorTime,
                                               request.UserName);
                        return response;
                }

                public virtual ApiErrorLogRequestModel MapResponseToRequest(
                        ApiErrorLogResponseModel response)
                {
                        var request = new ApiErrorLogRequestModel();
                        request.SetProperties(
                                response.ErrorLine,
                                response.ErrorMessage,
                                response.ErrorNumber,
                                response.ErrorProcedure,
                                response.ErrorSeverity,
                                response.ErrorState,
                                response.ErrorTime,
                                response.UserName);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>8fad42b1b238d5b2534ad037d9812cf2</Hash>
</Codenesium>*/