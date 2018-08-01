using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IDALMachinePolicyMapper
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
    <Hash>189efce1e854514ed169b830c737b584</Hash>
</Codenesium>*/