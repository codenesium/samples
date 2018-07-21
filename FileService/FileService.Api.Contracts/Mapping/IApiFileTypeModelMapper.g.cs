using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Contracts
{
        public interface IApiFileTypeModelMapper
        {
                ApiFileTypeResponseModel MapRequestToResponse(
                        int id,
                        ApiFileTypeRequestModel request);

                ApiFileTypeRequestModel MapResponseToRequest(
                        ApiFileTypeResponseModel response);

                JsonPatchDocument<ApiFileTypeRequestModel> CreatePatch(ApiFileTypeRequestModel model);
        }
}

/*<Codenesium>
    <Hash>c0a6c32407badfaef8a187626d089396</Hash>
</Codenesium>*/