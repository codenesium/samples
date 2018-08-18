using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALVariableSetMapper
	{
		VariableSet MapBOToEF(
			BOVariableSet bo);

		BOVariableSet MapEFToBO(
			VariableSet efVariableSet);

		List<BOVariableSet> MapEFToBO(
			List<VariableSet> records);
	}
}

/*<Codenesium>
    <Hash>34026e3e112c8fc2c22f72c59ff9c355</Hash>
</Codenesium>*/