using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiPersonModelMapper
        {
                ApiPersonResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiPersonRequestModel request);

                ApiPersonRequestModel MapResponseToRequest(
                        ApiPersonResponseModel response);
        }
}

/*<Codenesium>
    <Hash>1fdd4023706ab0c47fd5516cac9fa036</Hash>
</Codenesium>*/