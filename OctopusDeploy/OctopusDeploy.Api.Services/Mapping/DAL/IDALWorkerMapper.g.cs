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
    <Hash>752278df884bb47d2ad001e6eef0a93e</Hash>
</Codenesium>*/