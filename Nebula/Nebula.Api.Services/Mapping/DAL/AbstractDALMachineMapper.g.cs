using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractDALMachineMapper
	{
		public virtual Machine MapModelToEntity(
			int id,
			ApiMachineServerRequestModel model
			)
		{
			Machine item = new Machine();
			item.SetProperties(
				id,
				model.Description,
				model.JwtKey,
				model.LastIpAddress,
				model.MachineGuid,
				model.Name);
			return item;
		}

		public virtual ApiMachineServerResponseModel MapEntityToModel(
			Machine item)
		{
			var model = new ApiMachineServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Description,
			                    item.JwtKey,
			                    item.LastIpAddress,
			                    item.MachineGuid,
			                    item.Name);

			return model;
		}

		public virtual List<ApiMachineServerResponseModel> MapEntityToModel(
			List<Machine> items)
		{
			List<ApiMachineServerResponseModel> response = new List<ApiMachineServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>18a4b9035e0ce51c5254b2445f9f5bbd</Hash>
</Codenesium>*/