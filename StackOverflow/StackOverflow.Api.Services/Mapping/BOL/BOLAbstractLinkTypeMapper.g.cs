using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class BOLAbstractLinkTypeMapper
	{
		public virtual BOLinkType MapModelToBO(
			int id,
			ApiLinkTypeServerRequestModel model
			)
		{
			BOLinkType boLinkType = new BOLinkType();
			boLinkType.SetProperties(
				id,
				model.Type);
			return boLinkType;
		}

		public virtual ApiLinkTypeServerResponseModel MapBOToModel(
			BOLinkType boLinkType)
		{
			var model = new ApiLinkTypeServerResponseModel();

			model.SetProperties(boLinkType.Id, boLinkType.Type);

			return model;
		}

		public virtual List<ApiLinkTypeServerResponseModel> MapBOToModel(
			List<BOLinkType> items)
		{
			List<ApiLinkTypeServerResponseModel> response = new List<ApiLinkTypeServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>378e9227eb5e9f12167105a50f99dee5</Hash>
</Codenesium>*/