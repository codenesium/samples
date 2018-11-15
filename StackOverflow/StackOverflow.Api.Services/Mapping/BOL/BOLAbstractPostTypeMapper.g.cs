using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class BOLAbstractPostTypeMapper
	{
		public virtual BOPostType MapModelToBO(
			int id,
			ApiPostTypeServerRequestModel model
			)
		{
			BOPostType boPostType = new BOPostType();
			boPostType.SetProperties(
				id,
				model.Type);
			return boPostType;
		}

		public virtual ApiPostTypeServerResponseModel MapBOToModel(
			BOPostType boPostType)
		{
			var model = new ApiPostTypeServerResponseModel();

			model.SetProperties(boPostType.Id, boPostType.Type);

			return model;
		}

		public virtual List<ApiPostTypeServerResponseModel> MapBOToModel(
			List<BOPostType> items)
		{
			List<ApiPostTypeServerResponseModel> response = new List<ApiPostTypeServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>32d59771c4b3f3b1f75218c9e3b15812</Hash>
</Codenesium>*/