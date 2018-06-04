using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
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
    <Hash>3b0a04fbcbe75f7897744364f1d09967</Hash>
</Codenesium>*/