using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class BOLAbstractTagMapper
	{
		public virtual BOTag MapModelToBO(
			int id,
			ApiTagRequestModel model
			)
		{
			BOTag boTag = new BOTag();
			boTag.SetProperties(
				id,
				model.Count,
				model.ExcerptPostId,
				model.TagName,
				model.WikiPostId);
			return boTag;
		}

		public virtual ApiTagResponseModel MapBOToModel(
			BOTag boTag)
		{
			var model = new ApiTagResponseModel();

			model.SetProperties(boTag.Id, boTag.Count, boTag.ExcerptPostId, boTag.TagName, boTag.WikiPostId);

			return model;
		}

		public virtual List<ApiTagResponseModel> MapBOToModel(
			List<BOTag> items)
		{
			List<ApiTagResponseModel> response = new List<ApiTagResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>17fb23830d0ebc00278575ef93cd4f5c</Hash>
</Codenesium>*/