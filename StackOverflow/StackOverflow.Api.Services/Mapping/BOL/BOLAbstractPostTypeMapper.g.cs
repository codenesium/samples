using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class BOLAbstractPostTypeMapper
	{
		public virtual BOPostType MapModelToBO(
			int id,
			ApiPostTypeRequestModel model
			)
		{
			BOPostType boPostType = new BOPostType();
			boPostType.SetProperties(
				id,
				model.Type);
			return boPostType;
		}

		public virtual ApiPostTypeResponseModel MapBOToModel(
			BOPostType boPostType)
		{
			var model = new ApiPostTypeResponseModel();

			model.SetProperties(boPostType.Id, boPostType.Type);

			return model;
		}

		public virtual List<ApiPostTypeResponseModel> MapBOToModel(
			List<BOPostType> items)
		{
			List<ApiPostTypeResponseModel> response = new List<ApiPostTypeResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e83be0a2d1545d3f6b3107eb3f9936e4</Hash>
</Codenesium>*/