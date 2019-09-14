using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public class DALPostLinkMapper : IDALPostLinkMapper
	{
		public virtual PostLink MapModelToEntity(
			int id,
			ApiPostLinkServerRequestModel model
			)
		{
			PostLink item = new PostLink();
			item.SetProperties(
				id,
				model.CreationDate,
				model.LinkTypeId,
				model.PostId,
				model.RelatedPostId);
			return item;
		}

		public virtual ApiPostLinkServerResponseModel MapEntityToModel(
			PostLink item)
		{
			var model = new ApiPostLinkServerResponseModel();

			model.SetProperties(item.Id,
			                    item.CreationDate,
			                    item.LinkTypeId,
			                    item.PostId,
			                    item.RelatedPostId);
			if (item.LinkTypeIdNavigation != null)
			{
				var linkTypeIdModel = new ApiLinkTypeServerResponseModel();
				linkTypeIdModel.SetProperties(
					item.LinkTypeIdNavigation.Id,
					item.LinkTypeIdNavigation.RwType);

				model.SetLinkTypeIdNavigation(linkTypeIdModel);
			}

			if (item.PostIdNavigation != null)
			{
				var postIdModel = new ApiPostServerResponseModel();
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
				var relatedPostIdModel = new ApiPostServerResponseModel();
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

		public virtual List<ApiPostLinkServerResponseModel> MapEntityToModel(
			List<PostLink> items)
		{
			List<ApiPostLinkServerResponseModel> response = new List<ApiPostLinkServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c7741a2293663aa09e9e81e6c4abf229</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/