using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractDALTagMapper
	{
		public virtual Tag MapModelToEntity(
			int id,
			ApiTagServerRequestModel model
			)
		{
			Tag item = new Tag();
			item.SetProperties(
				id,
				model.Count,
				model.ExcerptPostId,
				model.TagName,
				model.WikiPostId);
			return item;
		}

		public virtual ApiTagServerResponseModel MapEntityToModel(
			Tag item)
		{
			var model = new ApiTagServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Count,
			                    item.ExcerptPostId,
			                    item.TagName,
			                    item.WikiPostId);
			if (item.ExcerptPostIdNavigation != null)
			{
				var excerptPostIdModel = new ApiPostServerResponseModel();
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
				var wikiPostIdModel = new ApiPostServerResponseModel();
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

		public virtual List<ApiTagServerResponseModel> MapEntityToModel(
			List<Tag> items)
		{
			List<ApiTagServerResponseModel> response = new List<ApiTagServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>dee03a49ccea7029bcadfde191ad3761</Hash>
</Codenesium>*/