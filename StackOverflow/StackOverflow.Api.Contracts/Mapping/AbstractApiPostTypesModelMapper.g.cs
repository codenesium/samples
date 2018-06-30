using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Contracts
{
        public abstract class AbstractApiPostTypesModelMapper
        {
                public virtual ApiPostTypesResponseModel MapRequestToResponse(
                        int id,
                        ApiPostTypesRequestModel request)
                {
                        var response = new ApiPostTypesResponseModel();
                        response.SetProperties(id,
                                               request.Type);
                        return response;
                }

                public virtual ApiPostTypesRequestModel MapResponseToRequest(
                        ApiPostTypesResponseModel response)
                {
                        var request = new ApiPostTypesRequestModel();
                        request.SetProperties(
                                response.Type);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>b329e9d7017800583528cf2aec488cb2</Hash>
</Codenesium>*/