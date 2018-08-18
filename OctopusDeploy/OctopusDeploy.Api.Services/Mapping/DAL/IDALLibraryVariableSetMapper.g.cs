using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALLibraryVariableSetMapper
	{
		LibraryVariableSet MapBOToEF(
			BOLibraryVariableSet bo);

		BOLibraryVariableSet MapEFToBO(
			LibraryVariableSet efLibraryVariableSet);

		List<BOLibraryVariableSet> MapEFToBO(
			List<LibraryVariableSet> records);
	}
}

/*<Codenesium>
    <Hash>96ca39b6f8100b8228d7615914283d88</Hash>
</Codenesium>*/