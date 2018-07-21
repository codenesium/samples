using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiIllustrationModelMapper
        {
                public virtual ApiIllustrationResponseModel MapRequestToResponse(
                        int illustrationID,
                        ApiIllustrationRequestModel request)
                {
                        var response = new ApiIllustrationResponseModel();
                        response.SetProperties(illustrationID,
                                               request.Diagram,
                                               request.ModifiedDate);
                        return response;
                }

                public virtual ApiIllustrationRequestModel MapResponseToRequest(
                        ApiIllustrationResponseModel response)
                {
                        var request = new ApiIllustrationRequestModel();
                        request.SetProperties(
                                response.Diagram,
                                response.ModifiedDate);
                        return request;
                }

                public JsonPatchDocument<ApiIllustrationRequestModel> CreatePatch(ApiIllustrationRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiIllustrationRequestModel>();
                        patch.Replace(x => x.Diagram, model.Diagram);
                        patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>5c35a55c7f3509df60aa1d4158d57df9</Hash>
</Codenesium>*/