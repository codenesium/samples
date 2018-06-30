using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Contracts
{
        public interface IApiChainModelMapper
        {
                ApiChainResponseModel MapRequestToResponse(
                        int id,
                        ApiChainRequestModel request);

                ApiChainRequestModel MapResponseToRequest(
                        ApiChainResponseModel response);
        }
}

/*<Codenesium>
    <Hash>d36302559209b530f38eabe333c7421c</Hash>
</Codenesium>*/