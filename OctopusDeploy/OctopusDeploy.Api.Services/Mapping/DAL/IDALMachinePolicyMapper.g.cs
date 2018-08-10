using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALMachinePolicyMapper
	{
		MachinePolicy MapBOToEF(
			BOMachinePolicy bo);

		BOMachinePolicy MapEFToBO(
			MachinePolicy efMachinePolicy);

		List<BOMachinePolicy> MapEFToBO(
			List<MachinePolicy> records);
	}
}

/*<Codenesium>
    <Hash>c6a1dcedc5ae652ad068874f4eacaf54</Hash>
</Codenesium>*/