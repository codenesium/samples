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
    <Hash>be1299fcef47c24e0362b46366cdc761</Hash>
</Codenesium>*/