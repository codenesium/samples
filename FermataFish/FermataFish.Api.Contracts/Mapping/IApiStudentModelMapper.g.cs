using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
        public interface IApiStudentModelMapper
        {
                ApiStudentResponseModel MapRequestToResponse(
                        int id,
                        ApiStudentRequestModel request);

                ApiStudentRequestModel MapResponseToRequest(
                        ApiStudentResponseModel response);

                JsonPatchDocument<ApiStudentRequestModel> CreatePatch(ApiStudentRequestModel model);
        }
}

/*<Codenesium>
    <Hash>be497e67923e4c4483e46e274d7435a0</Hash>
</Codenesium>*/