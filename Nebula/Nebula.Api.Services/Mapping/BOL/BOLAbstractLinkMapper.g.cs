using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
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
				model.DynamicParameters,
				model.ExternalId,
				model.LinkStatusId,
				model.Name,
				model.Order,
				model.Response,
				model.StaticParameters,
				model.TimeoutInSeconds);
			return boLink;
		}

		public virtual ApiLinkResponseModel MapBOToModel(
			BOLink boLink)
		{
			var model = new ApiLinkResponseModel();

			model.SetProperties(boLink.AssignedMachineId, boLink.ChainId, boLink.DateCompleted, boLink.DateStarted, boLink.DynamicParameters, boLink.ExternalId, boLink.Id, boLink.LinkStatusId, boLink.Name, boLink.Order, boLink.Response, boLink.StaticParameters, boLink.TimeoutInSeconds);

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
    <Hash>5e9f996ad298f8650632bee5d696d8ff</Hash>
</Codenesium>*/