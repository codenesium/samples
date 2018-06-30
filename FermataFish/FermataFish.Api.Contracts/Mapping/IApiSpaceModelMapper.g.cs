using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Contracts
{
        public interface IApiSpaceModelMapper
        {
                ApiSpaceResponseModel MapRequestToResponse(
                        int id,
                        ApiSpaceRequestModel request);

                ApiSpaceRequestModel MapResponseToRequest(
                        ApiSpaceResponseModel response);
        }
}

/*<Codenesium>
    <Hash>5b02acf31fd6e95275ecdaef8553b196</Hash>
</Codenesium>*/