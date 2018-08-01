using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IDALVariableSetMapper
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
    <Hash>02980332fb4fe39f08d2b518f69bddd1</Hash>
</Codenesium>*/