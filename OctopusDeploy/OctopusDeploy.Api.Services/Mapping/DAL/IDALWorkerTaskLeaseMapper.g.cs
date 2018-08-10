using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALWorkerTaskLeaseMapper
	{
		WorkerTaskLease MapBOToEF(
			BOWorkerTaskLease bo);

		BOWorkerTaskLease MapEFToBO(
			WorkerTaskLease efWorkerTaskLease);

		List<BOWorkerTaskLease> MapEFToBO(
			List<WorkerTaskLease> records);
	}
}

/*<Codenesium>
    <Hash>841b65edbf277b1baf1e5a79f467eb4e</Hash>
</Codenesium>*/