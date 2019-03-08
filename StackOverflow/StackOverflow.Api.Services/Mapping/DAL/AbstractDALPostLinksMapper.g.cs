using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractDALPostLinksMapper
	{
		public virtual PostLinks MapModelToEntity(
			int id,
			ApiPostLinksServerRequestModel model
			)
		{
			PostLinks item = new PostLinks();
			item.SetProperties(
				id,
				model.CreationDate,
				model.LinkTypeId,
				model.PostId,
				model.RelatedPostId);
			return item;
		}

		public virtual ApiPostLinksServerResponseModel MapEntityToModel(
			PostLinks item)
		{
			var model = new ApiPostLinksServerResponseModel();

			model.SetProperties(item.Id,
			                    item.CreationDate,
			                    item.LinkTypeId,
			                    item.PostId,
			                    item.RelatedPostId);
			if (item.LinkTypeIdNavigation != null)
			{
				var linkTypeIdModel = new ApiLinkTypesServerResponseModel();
				linkTypeIdModel.SetProperties(
					item.LinkTypeIdNavigation.Id,
					item.LinkTypeIdNavigation.RwType);

				model.SetLinkTypeIdNavigation(linkTypeIdModel);
			}

			if (item.PostIdNavigation != null)
			{
				var postIdModel = new ApiPostsServerResponseModel();
				postIdModel.SetProperties(
					item.PostIdNavigation.Id,
					item.PostIdNavigation.AcceptedAnswerId,
					item.PostIdNavigation.AnswerCount,
					item.PostIdNavigation.Body,
					item.PostIdNavigation.ClosedDate,
					item.PostIdNavigation.CommentCount,
					item.PostIdNavigation.CommunityOwnedDate,
					item.PostIdNavigation.CreationDate,
					item.PostIdNavigation.FavoriteCount,
					item.PostIdNavigation.LastActivityDate,
					item.PostIdNavigation.LastEditDate,
					item.PostIdNavigation.LastEditorDisplayName,
					item.PostIdNavigation.LastEditorUserId,
					item.PostIdNavigation.OwnerUserId,
					item.PostIdNavigation.ParentId,
					item.PostIdNavigation.PostTypeId,
					item.PostIdNavigation.Score,
					item.PostIdNavigation.Tag,
					item.PostIdNavigation.Title,
					item.PostIdNavigation.ViewCount);

				model.SetPostIdNavigation(postIdModel);
			}

			if (item.RelatedPostIdNavigation != null)
			{
				var relatedPostIdModel = new ApiPostsServerResponseModel();
				relatedPostIdModel.SetProperties(
					item.RelatedPostIdNavigation.Id,
					item.RelatedPostIdNavigation.AcceptedAnswerId,
					item.RelatedPostIdNavigation.AnswerCount,
					item.RelatedPostIdNavigation.Body,
					item.RelatedPostIdNavigation.ClosedDate,
					item.RelatedPostIdNavigation.CommentCount,
					item.RelatedPostIdNavigation.CommunityOwnedDate,
					item.RelatedPostIdNavigation.CreationDate,
					item.RelatedPostIdNavigation.FavoriteCount,
					item.RelatedPostIdNavigation.LastActivityDate,
					item.RelatedPostIdNavigation.LastEditDate,
					item.RelatedPostIdNavigation.LastEditorDisplayName,
					item.RelatedPostIdNavigation.LastEditorUserId,
					item.RelatedPostIdNavigation.OwnerUserId,
					item.RelatedPostIdNavigation.ParentId,
					item.RelatedPostIdNavigation.PostTypeId,
					item.RelatedPostIdNavigation.Score,
					item.RelatedPostIdNavigation.Tag,
					item.RelatedPostIdNavigation.Title,
					item.RelatedPostIdNavigation.ViewCount);

				model.SetRelatedPostIdNavigation(relatedPostIdModel);
			}

			return model;
		}

		public virtual List<ApiPostLinksServerResponseModel> MapEntityToModel(
			List<PostLinks> items)
		{
			List<ApiPostLinksServerResponseModel> response = new List<ApiPostLinksServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>58293bbbacace95092f74aa7e6a4db2a</Hash>
</Codenesium>*/