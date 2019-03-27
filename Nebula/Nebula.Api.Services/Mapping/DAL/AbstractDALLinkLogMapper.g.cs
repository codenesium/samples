using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractDALLinkLogMapper
	{
		public virtual LinkLog MapModelToEntity(
			int id,
			ApiLinkLogServerRequestModel model
			)
		{
			LinkLog item = new LinkLog();
			item.SetProperties(
				id,
				model.DateEntered,
				model.LinkId,
				model.Log);
			return item;
		}

		public virtual ApiLinkLogServerResponseModel MapEntityToModel(
			LinkLog item)
		{
			var model = new ApiLinkLogServerResponseModel();

			model.SetProperties(item.Id,
			                    item.DateEntered,
			                    item.LinkId,
			                    item.Log);
			if (item.LinkIdNavigation != null)
			{
				var linkIdModel = new ApiLinkServerResponseModel();
				linkIdModel.SetProperties(
					item.LinkIdNavigation.Id,
					item.LinkIdNavigation.AssignedMachineId,
					item.LinkIdNavigation.ChainId,
					item.LinkIdNavigation.DateCompleted,
					item.LinkIdNavigation.DateStarted,
					item.LinkIdNavigation.DynamicParameters,
					item.LinkIdNavigation.ExternalId,
					item.LinkIdNavigation.LinkStatusId,
					item.LinkIdNavigation.Name,
					item.LinkIdNavigation.Order,
					item.LinkIdNavigation.Response,
					item.LinkIdNavigation.StaticParameters,
					item.LinkIdNavigation.TimeoutInSeconds);

				model.SetLinkIdNavigation(linkIdModel);
			}

			return model;
		}

		public virtual List<ApiLinkLogServerResponseModel> MapEntityToModel(
			List<LinkLog> items)
		{
			List<ApiLinkLogServerResponseModel> response = new List<ApiLinkLogServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>4d365c7bfa02740a6069ddf52d4e94e0</Hash>
</Codenesium>*/