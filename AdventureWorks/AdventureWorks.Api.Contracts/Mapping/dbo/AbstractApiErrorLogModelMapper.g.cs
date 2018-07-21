using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

                public JsonPatchDocument<ApiErrorLogRequestModel> CreatePatch(ApiErrorLogRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiErrorLogRequestModel>();
                        patch.Replace(x => x.ErrorLine, model.ErrorLine);
                        patch.Replace(x => x.ErrorMessage, model.ErrorMessage);
                        patch.Replace(x => x.ErrorNumber, model.ErrorNumber);
                        patch.Replace(x => x.ErrorProcedure, model.ErrorProcedure);
                        patch.Replace(x => x.ErrorSeverity, model.ErrorSeverity);
                        patch.Replace(x => x.ErrorState, model.ErrorState);
                        patch.Replace(x => x.ErrorTime, model.ErrorTime);
                        patch.Replace(x => x.UserName, model.UserName);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>e80ca504a2a75d11f280f57b909e45be</Hash>
</Codenesium>*/