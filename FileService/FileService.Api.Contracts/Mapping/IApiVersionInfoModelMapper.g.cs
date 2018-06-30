using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Contracts
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
    <Hash>677119d0e9189741d76f84f00c954956</Hash>
</Codenesium>*/