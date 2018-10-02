using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public abstract class BOLAbstractLinkMapper
	{
		public virtual BOLink MapModelToBO(
			int id,
			ApiLinkRequestModel model
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

		public virtual ApiLinkResponseModel MapBOToModel(
			BOLink boLink)
		{
			var model = new ApiLinkResponseModel();

			model.SetProperties(boLink.Id, boLink.AssignedMachineId, boLink.ChainId, boLink.DateCompleted, boLink.DateStarted, boLink.DynamicParameter, boLink.ExternalId, boLink.LinkStatusId, boLink.Name, boLink.Order, boLink.Response, boLink.StaticParameter, boLink.TimeoutInSecond);

			return model;
		}

		public virtual List<ApiLinkResponseModel> MapBOToModel(
			List<BOLink> items)
		{
			List<ApiLinkResponseModel> response = new List<ApiLinkResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>107d1ef024aa82e11c6f7103a9ae11d4</Hash>
</Codenesium>*/