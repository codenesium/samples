using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IDALInterruptionMapper
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
    <Hash>0ea44ca2e22af787f50f4c59d089a7e6</Hash>
</Codenesium>*/