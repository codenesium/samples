using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>fb0efe8c7b369f32760d7303cfd3c7a0</Hash>
</Codenesium>*/