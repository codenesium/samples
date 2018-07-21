using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiProductModelIllustrationModelMapper
        {
                ApiProductModelIllustrationResponseModel MapRequestToResponse(
                        int productModelID,
                        ApiProductModelIllustrationRequestModel request);

                ApiProductModelIllustrationRequestModel MapResponseToRequest(
                        ApiProductModelIllustrationResponseModel response);

                JsonPatchDocument<ApiProductModelIllustrationRequestModel> CreatePatch(ApiProductModelIllustrationRequestModel model);
        }
}

/*<Codenesium>
    <Hash>f4dde55707c31a3c4505e4337154c5a8</Hash>
</Codenesium>*/