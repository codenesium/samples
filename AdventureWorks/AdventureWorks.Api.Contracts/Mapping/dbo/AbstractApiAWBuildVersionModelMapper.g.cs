using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiAWBuildVersionModelMapper
        {
                public virtual ApiAWBuildVersionResponseModel MapRequestToResponse(
                        int systemInformationID,
                        ApiAWBuildVersionRequestModel request)
                {
                        var response = new ApiAWBuildVersionResponseModel();
                        response.SetProperties(systemInformationID,
                                               request.Database_Version,
                                               request.ModifiedDate,
                                               request.VersionDate);
                        return response;
                }

                public virtual ApiAWBuildVersionRequestModel MapResponseToRequest(
                        ApiAWBuildVersionResponseModel response)
                {
                        var request = new ApiAWBuildVersionRequestModel();
                        request.SetProperties(
                                response.Database_Version,
                                response.ModifiedDate,
                                response.VersionDate);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>54c3111f2a4cfcbe63deeeabdfe58195</Hash>
</Codenesium>*/