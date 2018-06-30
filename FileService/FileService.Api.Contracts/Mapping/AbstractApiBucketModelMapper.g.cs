using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Contracts
{
        public abstract class AbstractApiBucketModelMapper
        {
                public virtual ApiBucketResponseModel MapRequestToResponse(
                        int id,
                        ApiBucketRequestModel request)
                {
                        var response = new ApiBucketResponseModel();
                        response.SetProperties(id,
                                               request.ExternalId,
                                               request.Name);
                        return response;
                }

                public virtual ApiBucketRequestModel MapResponseToRequest(
                        ApiBucketResponseModel response)
                {
                        var request = new ApiBucketRequestModel();
                        request.SetProperties(
                                response.ExternalId,
                                response.Name);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>8e5ae3680b90188820f96a727cf74fcc</Hash>
</Codenesium>*/