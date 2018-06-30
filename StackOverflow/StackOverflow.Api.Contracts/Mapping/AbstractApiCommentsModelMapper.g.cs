using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Contracts
{
        public abstract class AbstractApiCommentsModelMapper
        {
                public virtual ApiCommentsResponseModel MapRequestToResponse(
                        int id,
                        ApiCommentsRequestModel request)
                {
                        var response = new ApiCommentsResponseModel();
                        response.SetProperties(id,
                                               request.CreationDate,
                                               request.PostId,
                                               request.Score,
                                               request.Text,
                                               request.UserId);
                        return response;
                }

                public virtual ApiCommentsRequestModel MapResponseToRequest(
                        ApiCommentsResponseModel response)
                {
                        var request = new ApiCommentsRequestModel();
                        request.SetProperties(
                                response.CreationDate,
                                response.PostId,
                                response.Score,
                                response.Text,
                                response.UserId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>25bfc05d2f5c10a82ebc296a63ce168f</Hash>
</Codenesium>*/