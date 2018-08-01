using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
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
    <Hash>d45a88d39a6a06c6f3db8da2f85c70a5</Hash>
</Codenesium>*/