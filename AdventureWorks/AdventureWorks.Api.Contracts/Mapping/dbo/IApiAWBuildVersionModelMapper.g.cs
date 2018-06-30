using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiAWBuildVersionModelMapper
        {
                ApiAWBuildVersionResponseModel MapRequestToResponse(
                        int systemInformationID,
                        ApiAWBuildVersionRequestModel request);

                ApiAWBuildVersionRequestModel MapResponseToRequest(
                        ApiAWBuildVersionResponseModel response);
        }
}

/*<Codenesium>
    <Hash>5e39922a1bfafe8eb6822c6eec9ebacc</Hash>
</Codenesium>*/