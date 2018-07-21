using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
        public abstract class AbstractApiTeacherModelMapper
        {
                public virtual ApiTeacherResponseModel MapRequestToResponse(
                        int id,
                        ApiTeacherRequestModel request)
                {
                        var response = new ApiTeacherResponseModel();
                        response.SetProperties(id,
                                               request.Birthday,
                                               request.Email,
                                               request.FirstName,
                                               request.LastName,
                                               request.Phone,
                                               request.StudioId);
                        return response;
                }

                public virtual ApiTeacherRequestModel MapResponseToRequest(
                        ApiTeacherResponseModel response)
                {
                        var request = new ApiTeacherRequestModel();
                        request.SetProperties(
                                response.Birthday,
                                response.Email,
                                response.FirstName,
                                response.LastName,
                                response.Phone,
                                response.StudioId);
                        return request;
                }

                public JsonPatchDocument<ApiTeacherRequestModel> CreatePatch(ApiTeacherRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiTeacherRequestModel>();
                        patch.Replace(x => x.Birthday, model.Birthday);
                        patch.Replace(x => x.Email, model.Email);
                        patch.Replace(x => x.FirstName, model.FirstName);
                        patch.Replace(x => x.LastName, model.LastName);
                        patch.Replace(x => x.Phone, model.Phone);
                        patch.Replace(x => x.StudioId, model.StudioId);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>c895c80a963a9a84f6f25dead4ce9ba4</Hash>
</Codenesium>*/