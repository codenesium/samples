using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public class DALLinkMapper : IDALLinkMapper
	{
		public virtual Link MapModelToEntity(
			int id,
			ApiLinkServerRequestModel model
			)
		{
			Link item = new Link();
			item.SetProperties(
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
			return item;
		}

		public virtual ApiLinkServerResponseModel MapEntityToModel(
			Link item)
		{
			var model = new ApiLinkServerResponseModel();

			model.SetProperties(item.Id,
			                    item.AssignedMachineId,
			                    item.ChainId,
			                    item.DateCompleted,
			                    item.DateStarted,
			                    item.DynamicParameters,
			                    item.ExternalId,
			                    item.LinkStatusId,
			                    item.Name,
			                    item.Order,
			                    item.Response,
			                    item.StaticParameters,
			                    item.TimeoutInSeconds);
			if (item.AssignedMachineIdNavigation != null)
			{
				var assignedMachineIdModel = new ApiMachineServerResponseModel();
				assignedMachineIdModel.SetProperties(
					item.AssignedMachineIdNavigation.Id,
					item.AssignedMachineIdNavigation.Description,
					item.AssignedMachineIdNavigation.JwtKey,
					item.AssignedMachineIdNavigation.LastIpAddress,
					item.AssignedMachineIdNavigation.MachineGuid,
					item.AssignedMachineIdNavigation.Name);

				model.SetAssignedMachineIdNavigation(assignedMachineIdModel);
			}

			if (item.ChainIdNavigation != null)
			{
				var chainIdModel = new ApiChainServerResponseModel();
				chainIdModel.SetProperties(
					item.ChainIdNavigation.Id,
					item.ChainIdNavigation.ChainStatusId,
					item.ChainIdNavigation.ExternalId,
					item.ChainIdNavigation.Name,
					item.ChainIdNavigation.TeamId);

				model.SetChainIdNavigation(chainIdModel);
			}

			if (item.LinkStatusIdNavigation != null)
			{
				var linkStatusIdModel = new ApiLinkStatusServerResponseModel();
				linkStatusIdModel.SetProperties(
					item.LinkStatusIdNavigation.Id,
					item.LinkStatusIdNavigation.Name);

				model.SetLinkStatusIdNavigation(linkStatusIdModel);
			}

			return model;
		}

		public virtual List<ApiLinkServerResponseModel> MapEntityToModel(
			List<Link> items)
		{
			List<ApiLinkServerResponseModel> response = new List<ApiLinkServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>68c4e9d695ee234a4d05ee3a29f8e5b6</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/