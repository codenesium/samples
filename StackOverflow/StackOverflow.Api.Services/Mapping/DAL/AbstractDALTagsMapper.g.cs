using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractDALTagsMapper
	{
		public virtual Tags MapModelToEntity(
			int id,
			ApiTagsServerRequestModel model
			)
		{
			Tags item = new Tags();
			item.SetProperties(
				id,
				model.Count,
				model.ExcerptPostId,
				model.TagName,
				model.WikiPostId);
			return item;
		}

		public virtual ApiTagsServerResponseModel MapEntityToModel(
			Tags item)
		{
			var model = new ApiTagsServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Count,
			                    item.ExcerptPostId,
			                    item.TagName,
			                    item.WikiPostId);
			if (item.ExcerptPostIdNavigation != null)
			{
				var excerptPostIdModel = new ApiPostsServerResponseModel();
				excerptPostIdModel.SetProperties(
					item.ExcerptPostIdNavigation.Id,
					item.ExcerptPostIdNavigation.AcceptedAnswerId,
					item.ExcerptPostIdNavigation.AnswerCount,
					item.ExcerptPostIdNavigation.Body,
					item.ExcerptPostIdNavigation.ClosedDate,
					item.ExcerptPostIdNavigation.CommentCount,
					item.ExcerptPostIdNavigation.CommunityOwnedDate,
					item.ExcerptPostIdNavigation.CreationDate,
					item.ExcerptPostIdNavigation.FavoriteCount,
					item.ExcerptPostIdNavigation.LastActivityDate,
					item.ExcerptPostIdNavigation.LastEditDate,
					item.ExcerptPostIdNavigation.LastEditorDisplayName,
					item.ExcerptPostIdNavigation.LastEditorUserId,
					item.ExcerptPostIdNavigation.OwnerUserId,
					item.ExcerptPostIdNavigation.ParentId,
					item.ExcerptPostIdNavigation.PostTypeId,
					item.ExcerptPostIdNavigation.Score,
					item.ExcerptPostIdNavigation.Tag,
					item.ExcerptPostIdNavigation.Title,
					item.ExcerptPostIdNavigation.ViewCount);

				model.SetExcerptPostIdNavigation(excerptPostIdModel);
			}

			if (item.WikiPostIdNavigation != null)
			{
				var wikiPostIdModel = new ApiPostsServerResponseModel();
				wikiPostIdModel.SetProperties(
					item.WikiPostIdNavigation.Id,
					item.WikiPostIdNavigation.AcceptedAnswerId,
					item.WikiPostIdNavigation.AnswerCount,
					item.WikiPostIdNavigation.Body,
					item.WikiPostIdNavigation.ClosedDate,
					item.WikiPostIdNavigation.CommentCount,
					item.WikiPostIdNavigation.CommunityOwnedDate,
					item.WikiPostIdNavigation.CreationDate,
					item.WikiPostIdNavigation.FavoriteCount,
					item.WikiPostIdNavigation.LastActivityDate,
					item.WikiPostIdNavigation.LastEditDate,
					item.WikiPostIdNavigation.LastEditorDisplayName,
					item.WikiPostIdNavigation.LastEditorUserId,
					item.WikiPostIdNavigation.OwnerUserId,
					item.WikiPostIdNavigation.ParentId,
					item.WikiPostIdNavigation.PostTypeId,
					item.WikiPostIdNavigation.Score,
					item.WikiPostIdNavigation.Tag,
					item.WikiPostIdNavigation.Title,
					item.WikiPostIdNavigation.ViewCount);

				model.SetWikiPostIdNavigation(wikiPostIdModel);
			}

			return model;
		}

		public virtual List<ApiTagsServerResponseModel> MapEntityToModel(
			List<Tags> items)
		{
			List<ApiTagsServerResponseModel> response = new List<ApiTagsServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>0e78b388c74ff08130fa63d04622dfa2</Hash>
</Codenesium>*/