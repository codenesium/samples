using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Contracts
{
        public abstract class AbstractApiFileModelMapper
        {
                public virtual ApiFileResponseModel MapRequestToResponse(
                        int id,
                        ApiFileRequestModel request)
                {
                        var response = new ApiFileResponseModel();
                        response.SetProperties(id,
                                               request.BucketId,
                                               request.DateCreated,
                                               request.Description,
                                               request.Expiration,
                                               request.Extension,
                                               request.ExternalId,
                                               request.FileSizeInBytes,
                                               request.FileTypeId,
                                               request.Location,
                                               request.PrivateKey,
                                               request.PublicKey);
                        return response;
                }

                public virtual ApiFileRequestModel MapResponseToRequest(
                        ApiFileResponseModel response)
                {
                        var request = new ApiFileRequestModel();
                        request.SetProperties(
                                response.BucketId,
                                response.DateCreated,
                                response.Description,
                                response.Expiration,
                                response.Extension,
                                response.ExternalId,
                                response.FileSizeInBytes,
                                response.FileTypeId,
                                response.Location,
                                response.PrivateKey,
                                response.PublicKey);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>e67f2d6e58782fb158d16a1b9fe24a6c</Hash>
</Codenesium>*/