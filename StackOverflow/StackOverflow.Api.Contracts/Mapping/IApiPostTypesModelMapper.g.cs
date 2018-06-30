using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Contracts
{
        public interface IApiPostTypesModelMapper
        {
                ApiPostTypesResponseModel MapRequestToResponse(
                        int id,
                        ApiPostTypesRequestModel request);

                ApiPostTypesRequestModel MapResponseToRequest(
                        ApiPostTypesResponseModel response);
        }
}

/*<Codenesium>
    <Hash>fb3829d155e4ffd91b10a54b105d9437</Hash>
</Codenesium>*/