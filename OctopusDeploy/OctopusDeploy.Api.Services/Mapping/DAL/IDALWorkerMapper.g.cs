using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>29db41218b61c2b03006cde6b9cd02be</Hash>
</Codenesium>*/