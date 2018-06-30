using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiPasswordModelMapper
        {
                public virtual ApiPasswordResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiPasswordRequestModel request)
                {
                        var response = new ApiPasswordResponseModel();
                        response.SetProperties(businessEntityID,
                                               request.ModifiedDate,
                                               request.PasswordHash,
                                               request.PasswordSalt,
                                               request.Rowguid);
                        return response;
                }

                public virtual ApiPasswordRequestModel MapResponseToRequest(
                        ApiPasswordResponseModel response)
                {
                        var request = new ApiPasswordRequestModel();
                        request.SetProperties(
                                response.ModifiedDate,
                                response.PasswordHash,
                                response.PasswordSalt,
                                response.Rowguid);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>7eec229cdca55f0108b29e4c46abc247</Hash>
</Codenesium>*/