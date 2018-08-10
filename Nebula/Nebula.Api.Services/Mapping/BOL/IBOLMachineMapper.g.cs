using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public partial interface IBOLMachineMapper
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
    <Hash>4f479259599e77bb6a415e0f785286bc</Hash>
</Codenesium>*/