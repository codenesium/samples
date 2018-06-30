using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Contracts
{
        public interface IApiPostLinksModelMapper
        {
                ApiPostLinksResponseModel MapRequestToResponse(
                        int id,
                        ApiPostLinksRequestModel request);

                ApiPostLinksRequestModel MapResponseToRequest(
                        ApiPostLinksResponseModel response);
        }
}

/*<Codenesium>
    <Hash>87fd9fb32b70874d525fa9999c397c79</Hash>
</Codenesium>*/