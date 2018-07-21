using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
        public interface IApiMachineModelMapper
        {
                ApiMachineResponseModel MapRequestToResponse(
                        int id,
                        ApiMachineRequestModel request);

                ApiMachineRequestModel MapResponseToRequest(
                        ApiMachineResponseModel response);

                JsonPatchDocument<ApiMachineRequestModel> CreatePatch(ApiMachineRequestModel model);
        }
}

/*<Codenesium>
    <Hash>a7b78de80d595d54488f4418fac6b422</Hash>
</Codenesium>*/