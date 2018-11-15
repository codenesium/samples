using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public abstract class BOLAbstractLinkMapper
	{
		public virtual BOLink MapModelToBO(
			int id,
			ApiLinkServerRequestModel model
			)
		{
			BOLink boLink = new BOLink();
			boLink.SetProperties(
				id,
				model.AssignedMachineId,
				model.ChainId,
				model.DateCompleted,
				model.DateStarted,
				model.DynamicParameter,
				model.ExternalId,
				model.LinkStatusId,
				model.Name,
				model.Order,
				model.Response,
				model.StaticParameter,
				model.TimeoutInSecond);
			return boLink;
		}

		public virtual ApiLinkServerResponseModel MapBOToModel(
			BOLink boLink)
		{
			var model = new ApiLinkServerResponseModel();

			model.SetProperties(boLink.Id, boLink.AssignedMachineId, boLink.ChainId, boLink.DateCompleted, boLink.DateStarted, boLink.DynamicParameter, boLink.ExternalId, boLink.LinkStatusId, boLink.Name, boLink.Order, boLink.Response, boLink.StaticParameter, boLink.TimeoutInSecond);

			return model;
		}

		public virtual List<ApiLinkServerResponseModel> MapBOToModel(
			List<BOLink> items)
		{
			List<ApiLinkServerResponseModel> response = new List<ApiLinkServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>2633714b280e9b7e5e4a6e6fb189a9d0</Hash>
</Codenesium>*/