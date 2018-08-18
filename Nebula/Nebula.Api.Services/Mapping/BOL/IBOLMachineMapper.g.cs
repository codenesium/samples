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
    <Hash>0f64ac5b4aef17d17b7a51fb66e2029e</Hash>
</Codenesium>*/