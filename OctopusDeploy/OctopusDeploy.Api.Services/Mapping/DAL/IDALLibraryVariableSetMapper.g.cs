using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IDALLibraryVariableSetMapper
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
    <Hash>884f9a90e0b68675d8742009cba7a77c</Hash>
</Codenesium>*/