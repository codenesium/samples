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
			BOLink BOLink = new BOLink();

			BOLink.SetProperties(
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
			return BOLink;
		}

		public virtual ApiLinkResponseModel MapBOToModel(
			BOLink BOLink)
		{
			if (BOLink == null)
			{
				return null;
			}

			var model = new ApiLinkResponseModel();

			model.SetProperties(BOLink.AssignedMachineId, BOLink.ChainId, BOLink.DateCompleted, BOLink.DateStarted, BOLink.DynamicParameters, BOLink.ExternalId, BOLink.Id, BOLink.LinkStatusId, BOLink.Name, BOLink.Order, BOLink.Response, BOLink.StaticParameters, BOLink.TimeoutInSeconds);

			return model;
		}

		public virtual List<ApiLinkResponseModel> MapBOToModel(
			List<BOLink> BOs)
		{
			List<ApiLinkResponseModel> response = new List<ApiLinkResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a6c3f5f69a8ce1fcb2170f85fab83961</Hash>
</Codenesium>*/