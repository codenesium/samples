using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
        public abstract class AbstractApiLessonStatusModelMapper
        {
                public virtual ApiLessonStatusResponseModel MapRequestToResponse(
                        int id,
                        ApiLessonStatusRequestModel request)
                {
                        var response = new ApiLessonStatusResponseModel();
                        response.SetProperties(id,
                                               request.Name,
                                               request.StudioId);
                        return response;
                }

                public virtual ApiLessonStatusRequestModel MapResponseToRequest(
                        ApiLessonStatusResponseModel response)
                {
                        var request = new ApiLessonStatusRequestModel();
                        request.SetProperties(
                                response.Name,
                                response.StudioId);
                        return request;
                }

                public JsonPatchDocument<ApiLessonStatusRequestModel> CreatePatch(ApiLessonStatusRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiLessonStatusRequestModel>();
                        patch.Replace(x => x.Name, model.Name);
                        patch.Replace(x => x.StudioId, model.StudioId);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>97660149d468af5d8c43f3b2e44a65c2</Hash>
</Codenesium>*/