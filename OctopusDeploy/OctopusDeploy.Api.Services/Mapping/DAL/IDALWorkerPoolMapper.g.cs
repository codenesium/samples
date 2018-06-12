using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>461fe26a6c351dce0b10a03f4d4ee1e4</Hash>
</Codenesium>*/