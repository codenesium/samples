using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
        public interface IApiPostTypesModelMapper
        {
                ApiPostTypesResponseModel MapRequestToResponse(
                        int id,
                        ApiPostTypesRequestModel request);

                ApiPostTypesRequestModel MapResponseToRequest(
                        ApiPostTypesResponseModel response);

                JsonPatchDocument<ApiPostTypesRequestModel> CreatePatch(ApiPostTypesRequestModel model);
        }
}

/*<Codenesium>
    <Hash>ca211b3f0446ad4b69d317508cbf0439</Hash>
</Codenesium>*/