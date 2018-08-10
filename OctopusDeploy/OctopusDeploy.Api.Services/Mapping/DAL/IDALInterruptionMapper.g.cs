using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALInterruptionMapper
	{
		Interruption MapBOToEF(
			BOInterruption bo);

		BOInterruption MapEFToBO(
			Interruption efInterruption);

		List<BOInterruption> MapEFToBO(
			List<Interruption> records);
	}
}

/*<Codenesium>
    <Hash>77a38ee97db00be40278814017a8f9a3</Hash>
</Codenesium>*/