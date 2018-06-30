using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Contracts
{
        public interface IApiVersionInfoModelMapper
        {
                ApiVersionInfoResponseModel MapRequestToResponse(
                        long version,
                        ApiVersionInfoRequestModel request);

                ApiVersionInfoRequestModel MapResponseToRequest(
                        ApiVersionInfoResponseModel response);
        }
}

/*<Codenesium>
    <Hash>626ef1a09e0d45109c1c7d8ebc744013</Hash>
</Codenesium>*/