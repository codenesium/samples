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
    <Hash>d725f857aaad4322da14815455a93740</Hash>
</Codenesium>*/