using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Services
{
	public interface IBOLMachineMapper
	{
		BOMachine MapModelToBO(
			int id,
			ApiMachineRequestModel model);

		ApiMachineResponseModel MapBOToModel(
			BOMachine boMachine);

		List<ApiMachineResponseModel> MapBOToModel(
			List<BOMachine> items);
	}
}

/*<Codenesium>
    <Hash>8de78894f97a396df8cccd5e65b02ab4</Hash>
</Codenesium>*/