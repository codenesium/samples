using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class BOLAbstractTagMapper
	{
		public virtual BOTag MapModelToBO(
			int id,
			ApiTagServerRequestModel model
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

		public virtual ApiTagServerResponseModel MapBOToModel(
			BOTag boTag)
		{
			var model = new ApiTagServerResponseModel();

			model.SetProperties(boTag.Id, boTag.Count, boTag.ExcerptPostId, boTag.TagName, boTag.WikiPostId);

			return model;
		}

		public virtual List<ApiTagServerResponseModel> MapBOToModel(
			List<BOTag> items)
		{
			List<ApiTagServerResponseModel> response = new List<ApiTagServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>6546502c7cedf4104c9bcca650d715d5</Hash>
</Codenesium>*/