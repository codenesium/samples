using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>8bdb2a82444845701452ebb8d622f968</Hash>
</Codenesium>*/