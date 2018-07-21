using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiFeedModelMapper
        {
                ApiFeedResponseModel MapRequestToResponse(
                        string id,
                        ApiFeedRequestModel request);

                ApiFeedRequestModel MapResponseToRequest(
                        ApiFeedResponseModel response);

                JsonPatchDocument<ApiFeedRequestModel> CreatePatch(ApiFeedRequestModel model);
        }
}

/*<Codenesium>
    <Hash>0de10bf0f28d6f427386c3c7119a4045</Hash>
</Codenesium>*/