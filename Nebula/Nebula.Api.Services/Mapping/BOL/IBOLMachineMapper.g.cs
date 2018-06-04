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
			List<BOMachine> bos);
	}
}

/*<Codenesium>
    <Hash>768f48dc9b2ca0ee762040bd101e6a6f</Hash>
</Codenesium>*/