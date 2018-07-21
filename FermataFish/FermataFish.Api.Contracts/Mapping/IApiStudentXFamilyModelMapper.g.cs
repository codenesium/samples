using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
        public interface IApiStudentXFamilyModelMapper
        {
                ApiStudentXFamilyResponseModel MapRequestToResponse(
                        int id,
                        ApiStudentXFamilyRequestModel request);

                ApiStudentXFamilyRequestModel MapResponseToRequest(
                        ApiStudentXFamilyResponseModel response);

                JsonPatchDocument<ApiStudentXFamilyRequestModel> CreatePatch(ApiStudentXFamilyRequestModel model);
        }
}

/*<Codenesium>
    <Hash>70f2a04c5f7a17f835accd9fd068e512</Hash>
</Codenesium>*/