using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class BOLAbstractLinkTypeMapper
	{
		public virtual BOLinkType MapModelToBO(
			int id,
			ApiLinkTypeRequestModel model
			)
		{
			BOLinkType boLinkType = new BOLinkType();
			boLinkType.SetProperties(
				id,
				model.Type);
			return boLinkType;
		}

		public virtual ApiLinkTypeResponseModel MapBOToModel(
			BOLinkType boLinkType)
		{
			var model = new ApiLinkTypeResponseModel();

			model.SetProperties(boLinkType.Id, boLinkType.Type);

			return model;
		}

		public virtual List<ApiLinkTypeResponseModel> MapBOToModel(
			List<BOLinkType> items)
		{
			List<ApiLinkTypeResponseModel> response = new List<ApiLinkTypeResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>899d51fd8ec88db3971ba4550ad06e5c</Hash>
</Codenesium>*/