using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.BusinessObjects
{
	public abstract class AbstractBOLMachineMapper
	{
		public virtual DTOMachine MapModelToDTO(
			int id,
			ApiMachineRequestModel model
			)
		{
			DTOMachine dtoMachine = new DTOMachine();

			dtoMachine.SetProperties(
				id,
				model.Description,
				model.JwtKey,
				model.LastIpAddress,
				model.MachineGuid,
				model.Name);
			return dtoMachine;
		}

		public virtual ApiMachineResponseModel MapDTOToModel(
			DTOMachine dtoMachine)
		{
			if (dtoMachine == null)
			{
				return null;
			}

			var model = new ApiMachineResponseModel();

			model.SetProperties(dtoMachine.Description, dtoMachine.Id, dtoMachine.JwtKey, dtoMachine.LastIpAddress, dtoMachine.MachineGuid, dtoMachine.Name);

			return model;
		}

		public virtual List<ApiMachineResponseModel> MapDTOToModel(
			List<DTOMachine> dtos)
		{
			List<ApiMachineResponseModel> response = new List<ApiMachineResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>9c3145458f0d1ef66846916919fa1bde</Hash>
</Codenesium>*/