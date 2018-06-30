using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Contracts
{
        public interface IApiClaspModelMapper
        {
                ApiClaspResponseModel MapRequestToResponse(
                        int id,
                        ApiClaspRequestModel request);

                ApiClaspRequestModel MapResponseToRequest(
                        ApiClaspResponseModel response);
        }
}

/*<Codenesium>
    <Hash>b280d8eb622acb50a86e7d2d541f2b4b</Hash>
</Codenesium>*/