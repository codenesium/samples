using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiActionTemplateVersionModelMapper
        {
                ApiActionTemplateVersionResponseModel MapRequestToResponse(
                        string id,
                        ApiActionTemplateVersionRequestModel request);

                ApiActionTemplateVersionRequestModel MapResponseToRequest(
                        ApiActionTemplateVersionResponseModel response);

                JsonPatchDocument<ApiActionTemplateVersionRequestModel> CreatePatch(ApiActionTemplateVersionRequestModel model);
        }
}

/*<Codenesium>
    <Hash>b652451c86b2a47ce5bc031a3a62dc3a</Hash>
</Codenesium>*/