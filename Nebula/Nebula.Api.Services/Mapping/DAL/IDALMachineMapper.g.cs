using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
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
    <Hash>ce57b6af1ac436fcaafd06ac62174498</Hash>
</Codenesium>*/