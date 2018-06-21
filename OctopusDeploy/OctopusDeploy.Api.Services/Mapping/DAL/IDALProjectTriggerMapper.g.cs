using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public interface IDALProjectTriggerMapper
        {
                ProjectTrigger MapBOToEF(
                        BOProjectTrigger bo);

                BOProjectTrigger MapEFToBO(
                        ProjectTrigger efProjectTrigger);

                List<BOProjectTrigger> MapEFToBO(
                        List<ProjectTrigger> records);
        }
}

/*<Codenesium>
    <Hash>0192dfe20bf435f2e99a3c03a3ada198</Hash>
</Codenesium>*/