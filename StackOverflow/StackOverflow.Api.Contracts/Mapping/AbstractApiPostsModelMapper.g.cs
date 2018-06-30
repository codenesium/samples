using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Contracts
{
        public abstract class AbstractApiPostsModelMapper
        {
                public virtual ApiPostsResponseModel MapRequestToResponse(
                        int id,
                        ApiPostsRequestModel request)
                {
                        var response = new ApiPostsResponseModel();
                        response.SetProperties(id,
                                               request.AcceptedAnswerId,
                                               request.AnswerCount,
                                               request.Body,
                                               request.ClosedDate,
                                               request.CommentCount,
                                               request.CommunityOwnedDate,
                                               request.CreationDate,
                                               request.FavoriteCount,
                                               request.LastActivityDate,
                                               request.LastEditDate,
                                               request.LastEditorDisplayName,
                                               request.LastEditorUserId,
                                               request.OwnerUserId,
                                               request.ParentId,
                                               request.PostTypeId,
                                               request.Score,
                                               request.Tags,
                                               request.Title,
                                               request.ViewCount);
                        return response;
                }

                public virtual ApiPostsRequestModel MapResponseToRequest(
                        ApiPostsResponseModel response)
                {
                        var request = new ApiPostsRequestModel();
                        request.SetProperties(
                                response.AcceptedAnswerId,
                                response.AnswerCount,
                                response.Body,
                                response.ClosedDate,
                                response.CommentCount,
                                response.CommunityOwnedDate,
                                response.CreationDate,
                                response.FavoriteCount,
                                response.LastActivityDate,
                                response.LastEditDate,
                                response.LastEditorDisplayName,
                                response.LastEditorUserId,
                                response.OwnerUserId,
                                response.ParentId,
                                response.PostTypeId,
                                response.Score,
                                response.Tags,
                                response.Title,
                                response.ViewCount);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>efb2542b6072d9f14fded028ac0b7054</Hash>
</Codenesium>*/