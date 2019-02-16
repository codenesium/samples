using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public partial interface IDALMachineMapper
	{
		Machine MapModelToEntity(
			int id,
			ApiMachineServerRequestModel model);

		ApiMachineServerResponseModel MapEntityToModel(
			Machine item);

		List<ApiMachineServerResponseModel> MapEntityToModel(
			List<Machine> items);
	}
}

/*<Codenesium>
    <Hash>8e25166f4dfe7d9558eaf99debdfd15e</Hash>
</Codenesium>*/