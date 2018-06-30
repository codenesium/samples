using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Contracts
{
        public interface IApiMachineModelMapper
        {
                ApiMachineResponseModel MapRequestToResponse(
                        int id,
                        ApiMachineRequestModel request);

                ApiMachineRequestModel MapResponseToRequest(
                        ApiMachineResponseModel response);
        }
}

/*<Codenesium>
    <Hash>e54a4d2ff48cac6fbe7403e9ae348316</Hash>
</Codenesium>*/