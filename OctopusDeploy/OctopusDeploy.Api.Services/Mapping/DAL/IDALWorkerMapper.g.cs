using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALWorkerMapper
	{
		Worker MapBOToEF(
			BOWorker bo);

		BOWorker MapEFToBO(
			Worker efWorker);

		List<BOWorker> MapEFToBO(
			List<Worker> records);
	}
}

/*<Codenesium>
    <Hash>4bdef5ff65bcfe6c59edee94952f570b</Hash>
</Codenesium>*/