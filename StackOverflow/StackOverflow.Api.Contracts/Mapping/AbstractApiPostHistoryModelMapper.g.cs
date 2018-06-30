using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Contracts
{
        public abstract class AbstractApiPostHistoryModelMapper
        {
                public virtual ApiPostHistoryResponseModel MapRequestToResponse(
                        int id,
                        ApiPostHistoryRequestModel request)
                {
                        var response = new ApiPostHistoryResponseModel();
                        response.SetProperties(id,
                                               request.Comment,
                                               request.CreationDate,
                                               request.PostHistoryTypeId,
                                               request.PostId,
                                               request.RevisionGUID,
                                               request.Text,
                                               request.UserDisplayName,
                                               request.UserId);
                        return response;
                }

                public virtual ApiPostHistoryRequestModel MapResponseToRequest(
                        ApiPostHistoryResponseModel response)
                {
                        var request = new ApiPostHistoryRequestModel();
                        request.SetProperties(
                                response.Comment,
                                response.CreationDate,
                                response.PostHistoryTypeId,
                                response.PostId,
                                response.RevisionGUID,
                                response.Text,
                                response.UserDisplayName,
                                response.UserId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>49adae2d0305334fa5fd5baa3d3c61c9</Hash>
</Codenesium>*/