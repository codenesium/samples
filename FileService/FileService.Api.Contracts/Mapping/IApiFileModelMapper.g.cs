using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Contracts
{
        public interface IApiFileModelMapper
        {
                ApiFileResponseModel MapRequestToResponse(
                        int id,
                        ApiFileRequestModel request);

                ApiFileRequestModel MapResponseToRequest(
                        ApiFileResponseModel response);
        }
}

/*<Codenesium>
    <Hash>f5071449fc5bf115275eb704beacb786</Hash>
</Codenesium>*/