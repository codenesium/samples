using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
        public interface IApiFamilyModelMapper
        {
                ApiFamilyResponseModel MapRequestToResponse(
                        int id,
                        ApiFamilyRequestModel request);

                ApiFamilyRequestModel MapResponseToRequest(
                        ApiFamilyResponseModel response);

                JsonPatchDocument<ApiFamilyRequestModel> CreatePatch(ApiFamilyRequestModel model);
        }
}

/*<Codenesium>
    <Hash>cd9a5a3bdbb534821ba786e350fc88a7</Hash>
</Codenesium>*/