using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiMachineModelMapper
        {
                ApiMachineResponseModel MapRequestToResponse(
                        string id,
                        ApiMachineRequestModel request);

                ApiMachineRequestModel MapResponseToRequest(
                        ApiMachineResponseModel response);
        }
}

/*<Codenesium>
    <Hash>9ca3cfa141947cf2a458f4c268dd5586</Hash>
</Codenesium>*/