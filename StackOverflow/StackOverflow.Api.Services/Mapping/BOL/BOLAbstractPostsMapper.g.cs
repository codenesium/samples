using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
        public abstract class BOLAbstractPostsMapper
        {
                public virtual BOPosts MapModelToBO(
                        int id,
                        ApiPostsRequestModel model
                        )
                {
                        BOPosts boPosts = new BOPosts();
                        boPosts.SetProperties(
                                id,
                                model.AcceptedAnswerId,
                                model.AnswerCount,
                                model.Body,
                                model.ClosedDate,
                                model.CommentCount,
                                model.CommunityOwnedDate,
                                model.CreationDate,
                                model.FavoriteCount,
                                model.LastActivityDate,
                                model.LastEditDate,
                                model.LastEditorDisplayName,
                                model.LastEditorUserId,
                                model.OwnerUserId,
                                model.ParentId,
                                model.PostTypeId,
                                model.Score,
                                model.Tags,
                                model.Title,
                                model.ViewCount);
                        return boPosts;
                }

                public virtual ApiPostsResponseModel MapBOToModel(
                        BOPosts boPosts)
                {
                        var model = new ApiPostsResponseModel();

                        model.SetProperties(boPosts.AcceptedAnswerId, boPosts.AnswerCount, boPosts.Body, boPosts.ClosedDate, boPosts.CommentCount, boPosts.CommunityOwnedDate, boPosts.CreationDate, boPosts.FavoriteCount, boPosts.Id, boPosts.LastActivityDate, boPosts.LastEditDate, boPosts.LastEditorDisplayName, boPosts.LastEditorUserId, boPosts.OwnerUserId, boPosts.ParentId, boPosts.PostTypeId, boPosts.Score, boPosts.Tags, boPosts.Title, boPosts.ViewCount);

                        return model;
                }

                public virtual List<ApiPostsResponseModel> MapBOToModel(
                        List<BOPosts> items)
                {
                        List<ApiPostsResponseModel> response = new List<ApiPostsResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>38fa4bb9ad73904a0765c20fb357333b</Hash>
</Codenesium>*/