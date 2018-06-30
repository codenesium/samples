using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiProductModelMapper
        {
                ApiProductResponseModel MapRequestToResponse(
                        int productID,
                        ApiProductRequestModel request);

                ApiProductRequestModel MapResponseToRequest(
                        ApiProductResponseModel response);
        }
}

/*<Codenesium>
    <Hash>9d532b24aa0a0a381dfeec2876caeee8</Hash>
</Codenesium>*/