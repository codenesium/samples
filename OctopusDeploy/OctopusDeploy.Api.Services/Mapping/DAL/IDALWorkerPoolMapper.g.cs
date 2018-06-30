using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public interface IDALWorkerPoolMapper
        {
                WorkerPool MapBOToEF(
                        BOWorkerPool bo);

                BOWorkerPool MapEFToBO(
                        WorkerPool efWorkerPool);

                List<BOWorkerPool> MapEFToBO(
                        List<WorkerPool> records);
        }
}

/*<Codenesium>
    <Hash>7f2079ced3105c846fadd05b91eedb6c</Hash>
</Codenesium>*/