using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Contracts
{
        public abstract class AbstractApiFileTypeModelMapper
        {
                public virtual ApiFileTypeResponseModel MapRequestToResponse(
                        int id,
                        ApiFileTypeRequestModel request)
                {
                        var response = new ApiFileTypeResponseModel();
                        response.SetProperties(id,
                                               request.Name);
                        return response;
                }

                public virtual ApiFileTypeRequestModel MapResponseToRequest(
                        ApiFileTypeResponseModel response)
                {
                        var request = new ApiFileTypeRequestModel();
                        request.SetProperties(
                                response.Name);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>763c28c992f9e3837e1331a193e28a05</Hash>
</Codenesium>*/