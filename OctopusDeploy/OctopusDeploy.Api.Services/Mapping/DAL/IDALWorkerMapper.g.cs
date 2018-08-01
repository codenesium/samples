using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IDALWorkerMapper
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
    <Hash>03bf2e6dd32ac9984baf9d277f530823</Hash>
</Codenesium>*/