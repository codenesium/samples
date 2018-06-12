using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>952cd723b3b93775853d281e61b0d218</Hash>
</Codenesium>*/