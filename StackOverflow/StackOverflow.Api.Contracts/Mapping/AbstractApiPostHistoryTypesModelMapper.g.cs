using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Contracts
{
        public abstract class AbstractApiPostHistoryTypesModelMapper
        {
                public virtual ApiPostHistoryTypesResponseModel MapRequestToResponse(
                        int id,
                        ApiPostHistoryTypesRequestModel request)
                {
                        var response = new ApiPostHistoryTypesResponseModel();
                        response.SetProperties(id,
                                               request.Type);
                        return response;
                }

                public virtual ApiPostHistoryTypesRequestModel MapResponseToRequest(
                        ApiPostHistoryTypesResponseModel response)
                {
                        var request = new ApiPostHistoryTypesRequestModel();
                        request.SetProperties(
                                response.Type);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>b049e759ac0b5b605ce19039a7e642bf</Hash>
</Codenesium>*/