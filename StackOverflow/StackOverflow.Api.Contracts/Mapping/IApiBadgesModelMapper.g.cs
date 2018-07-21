using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
        public interface IApiBadgesModelMapper
        {
                ApiBadgesResponseModel MapRequestToResponse(
                        int id,
                        ApiBadgesRequestModel request);

                ApiBadgesRequestModel MapResponseToRequest(
                        ApiBadgesResponseModel response);

                JsonPatchDocument<ApiBadgesRequestModel> CreatePatch(ApiBadgesRequestModel model);
        }
}

/*<Codenesium>
    <Hash>845bb8cd83fbd974ff8800b4bb9d13b5</Hash>
</Codenesium>*/