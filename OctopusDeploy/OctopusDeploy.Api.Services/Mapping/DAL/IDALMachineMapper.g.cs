using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALMachineMapper
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
    <Hash>6926b80abacfcea602dedcafe8a44022</Hash>
</Codenesium>*/