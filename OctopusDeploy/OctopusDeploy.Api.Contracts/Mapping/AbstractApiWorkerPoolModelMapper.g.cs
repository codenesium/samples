using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiWorkerPoolModelMapper
        {
                public virtual ApiWorkerPoolResponseModel MapRequestToResponse(
                        string id,
                        ApiWorkerPoolRequestModel request)
                {
                        var response = new ApiWorkerPoolResponseModel();
                        response.SetProperties(id,
                                               request.IsDefault,
                                               request.JSON,
                                               request.Name,
                                               request.SortOrder);
                        return response;
                }

                public virtual ApiWorkerPoolRequestModel MapResponseToRequest(
                        ApiWorkerPoolResponseModel response)
                {
                        var request = new ApiWorkerPoolRequestModel();
                        request.SetProperties(
                                response.IsDefault,
                                response.JSON,
                                response.Name,
                                response.SortOrder);
                        return request;
                }

                public JsonPatchDocument<ApiWorkerPoolRequestModel> CreatePatch(ApiWorkerPoolRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiWorkerPoolRequestModel>();
                        patch.Replace(x => x.IsDefault, model.IsDefault);
                        patch.Replace(x => x.JSON, model.JSON);
                        patch.Replace(x => x.Name, model.Name);
                        patch.Replace(x => x.SortOrder, model.SortOrder);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>58c64c2b087e619e42c4c80cdccb75bb</Hash>
</Codenesium>*/