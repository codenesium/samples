using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public interface IDALLifecycleMapper
        {
                Lifecycle MapBOToEF(
                        BOLifecycle bo);

                BOLifecycle MapEFToBO(
                        Lifecycle efLifecycle);

                List<BOLifecycle> MapEFToBO(
                        List<Lifecycle> records);
        }
}

/*<Codenesium>
    <Hash>c0bb3f3730b3ec134e91e18c6bbd5e9f</Hash>
</Codenesium>*/