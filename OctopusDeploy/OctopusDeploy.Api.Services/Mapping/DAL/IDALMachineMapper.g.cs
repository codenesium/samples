using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IDALMachineMapper
	{
		Machine MapBOToEF(
			BOMachine bo);

		BOMachine MapEFToBO(
			Machine efMachine);

		List<BOMachine> MapEFToBO(
			List<Machine> records);
	}
}

/*<Codenesium>
    <Hash>b1dd515a5c9b07b859246fce59e0467b</Hash>
</Codenesium>*/