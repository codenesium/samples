using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiProductModelModelMapper
        {
                ApiProductModelResponseModel MapRequestToResponse(
                        int productModelID,
                        ApiProductModelRequestModel request);

                ApiProductModelRequestModel MapResponseToRequest(
                        ApiProductModelResponseModel response);
        }
}

/*<Codenesium>
    <Hash>16b4a01bf2332f190d980cff2a4bb0f5</Hash>
</Codenesium>*/