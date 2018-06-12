using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IDALInterruptionMapper
        {
                Interruption MapBOToEF(
                        BOInterruption bo);

                BOInterruption MapEFToBO(
                        Interruption efInterruption);

                List<BOInterruption> MapEFToBO(
                        List<Interruption> records);
        }
}

/*<Codenesium>
    <Hash>f57a8584c1ce2bea4cac8bfe4634e922</Hash>
</Codenesium>*/