using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class BOLAbstractTagsMapper
	{
		public virtual BOTags MapModelToBO(
			int id,
			ApiTagsRequestModel model
			)
		{
			BOTags boTags = new BOTags();
			boTags.SetProperties(
				id,
				model.Count,
				model.ExcerptPostId,
				model.TagName,
				model.WikiPostId);
			return boTags;
		}

		public virtual ApiTagsResponseModel MapBOToModel(
			BOTags boTags)
		{
			var model = new ApiTagsResponseModel();

			model.SetProperties(boTags.Id, boTags.Count, boTags.ExcerptPostId, boTags.TagName, boTags.WikiPostId);

			return model;
		}

		public virtual List<ApiTagsResponseModel> MapBOToModel(
			List<BOTags> items)
		{
			List<ApiTagsResponseModel> response = new List<ApiTagsResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>392f4fa5664e3241eb7451e9ec9778a9</Hash>
</Codenesium>*/