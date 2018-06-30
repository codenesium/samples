using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiPasswordModelMapper
        {
                ApiPasswordResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiPasswordRequestModel request);

                ApiPasswordRequestModel MapResponseToRequest(
                        ApiPasswordResponseModel response);
        }
}

/*<Codenesium>
    <Hash>6161474f07236acd6253737f96a792b1</Hash>
</Codenesium>*/