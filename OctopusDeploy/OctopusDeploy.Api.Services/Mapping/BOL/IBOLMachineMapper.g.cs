using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLMachineMapper
	{
		BOMachine MapModelToBO(
			string id,
			ApiMachineRequestModel model);

		ApiMachineResponseModel MapBOToModel(
			BOMachine boMachine);

		List<ApiMachineResponseModel> MapBOToModel(
			List<BOMachine> items);
	}
}

/*<Codenesium>
    <Hash>4fd74445ec7a9f65d9ff57ae5fefdb27</Hash>
</Codenesium>*/