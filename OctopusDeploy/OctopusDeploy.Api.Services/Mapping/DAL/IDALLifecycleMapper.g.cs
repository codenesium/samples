using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>511ace5fad4a14dbf1cf539965806c0a</Hash>
</Codenesium>*/