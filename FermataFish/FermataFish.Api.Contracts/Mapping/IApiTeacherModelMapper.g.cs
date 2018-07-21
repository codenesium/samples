using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
        public interface IApiTeacherModelMapper
        {
                ApiTeacherResponseModel MapRequestToResponse(
                        int id,
                        ApiTeacherRequestModel request);

                ApiTeacherRequestModel MapResponseToRequest(
                        ApiTeacherResponseModel response);

                JsonPatchDocument<ApiTeacherRequestModel> CreatePatch(ApiTeacherRequestModel model);
        }
}

/*<Codenesium>
    <Hash>fc38cb536136ca93a921f825bf301838</Hash>
</Codenesium>*/