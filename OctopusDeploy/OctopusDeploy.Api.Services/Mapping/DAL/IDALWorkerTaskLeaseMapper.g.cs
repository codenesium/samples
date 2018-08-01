using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IDALWorkerTaskLeaseMapper
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
    <Hash>e7daf0c5c8477e53101c180bf2e56df1</Hash>
</Codenesium>*/