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
			ApiMachineServerRequestModel model);

		ApiMachineServerResponseModel MapBOToModel(
			BOMachine boMachine);

		List<ApiMachineServerResponseModel> MapBOToModel(
			List<BOMachine> items);
	}
}

/*<Codenesium>
    <Hash>abc2643ed996cf1b534572a5975b8f77</Hash>
</Codenesium>*/