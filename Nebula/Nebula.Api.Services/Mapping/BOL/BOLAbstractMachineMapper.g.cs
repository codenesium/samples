using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public abstract class BOLAbstractMachineMapper
	{
		public virtual BOMachine MapModelToBO(
			int id,
			ApiMachineServerRequestModel model
			)
		{
			BOMachine boMachine = new BOMachine();
			boMachine.SetProperties(
				id,
				model.Description,
				model.JwtKey,
				model.LastIpAddress,
				model.MachineGuid,
				model.Name);
			return boMachine;
		}

		public virtual ApiMachineServerResponseModel MapBOToModel(
			BOMachine boMachine)
		{
			var model = new ApiMachineServerResponseModel();

			model.SetProperties(boMachine.Id, boMachine.Description, boMachine.JwtKey, boMachine.LastIpAddress, boMachine.MachineGuid, boMachine.Name);

			return model;
		}

		public virtual List<ApiMachineServerResponseModel> MapBOToModel(
			List<BOMachine> items)
		{
			List<ApiMachineServerResponseModel> response = new List<ApiMachineServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>5e0d76448ab3083fbe97a4bc303ab825</Hash>
</Codenesium>*/