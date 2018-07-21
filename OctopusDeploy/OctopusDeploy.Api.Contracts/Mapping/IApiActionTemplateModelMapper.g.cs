using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiActionTemplateModelMapper
        {
                ApiActionTemplateResponseModel MapRequestToResponse(
                        string id,
                        ApiActionTemplateRequestModel request);

                ApiActionTemplateRequestModel MapResponseToRequest(
                        ApiActionTemplateResponseModel response);

                JsonPatchDocument<ApiActionTemplateRequestModel> CreatePatch(ApiActionTemplateRequestModel model);
        }
}

/*<Codenesium>
    <Hash>f2b6b70ed1f58da0e2aa4180bb6a3672</Hash>
</Codenesium>*/