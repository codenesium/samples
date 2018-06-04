using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Services
{
	public abstract class BOLAbstractMachineMapper
	{
		public virtual BOMachine MapModelToBO(
			int id,
			ApiMachineRequestModel model
			)
		{
			BOMachine BOMachine = new BOMachine();

			BOMachine.SetProperties(
				id,
				model.Description,
				model.JwtKey,
				model.LastIpAddress,
				model.MachineGuid,
				model.Name);
			return BOMachine;
		}

		public virtual ApiMachineResponseModel MapBOToModel(
			BOMachine BOMachine)
		{
			if (BOMachine == null)
			{
				return null;
			}

			var model = new ApiMachineResponseModel();

			model.SetProperties(BOMachine.Description, BOMachine.Id, BOMachine.JwtKey, BOMachine.LastIpAddress, BOMachine.MachineGuid, BOMachine.Name);

			return model;
		}

		public virtual List<ApiMachineResponseModel> MapBOToModel(
			List<BOMachine> BOs)
		{
			List<ApiMachineResponseModel> response = new List<ApiMachineResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ed764e6ed7f37a1ebbbe83c52e579a4f</Hash>
</Codenesium>*/