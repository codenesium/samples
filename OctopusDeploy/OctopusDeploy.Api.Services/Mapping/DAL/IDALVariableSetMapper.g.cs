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
    <Hash>0a8c998c264eb6934f5a5711f29d87df</Hash>
</Codenesium>*/