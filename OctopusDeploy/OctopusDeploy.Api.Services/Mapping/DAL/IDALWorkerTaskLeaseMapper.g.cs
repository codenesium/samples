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
    <Hash>0589913dc9e71d2df4658f9a8ca4b2e0</Hash>
</Codenesium>*/