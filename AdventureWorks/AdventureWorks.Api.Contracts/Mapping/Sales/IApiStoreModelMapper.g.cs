using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiStoreModelMapper
        {
                ApiStoreResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiStoreRequestModel request);

                ApiStoreRequestModel MapResponseToRequest(
                        ApiStoreResponseModel response);
        }
}

/*<Codenesium>
    <Hash>9f146677b98844673c8c5cefc6b24c8e</Hash>
</Codenesium>*/