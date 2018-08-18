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
    <Hash>02dc6d7cbe7f014a3da3713655958bb0</Hash>
</Codenesium>*/