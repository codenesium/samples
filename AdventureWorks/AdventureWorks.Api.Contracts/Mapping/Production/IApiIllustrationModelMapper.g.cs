using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiIllustrationModelMapper
        {
                ApiIllustrationResponseModel MapRequestToResponse(
                        int illustrationID,
                        ApiIllustrationRequestModel request);

                ApiIllustrationRequestModel MapResponseToRequest(
                        ApiIllustrationResponseModel response);

                JsonPatchDocument<ApiIllustrationRequestModel> CreatePatch(ApiIllustrationRequestModel model);
        }
}

/*<Codenesium>
    <Hash>22890bcfb1fdd0188b38b4cbeb651d91</Hash>
</Codenesium>*/