using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IDALProjectGroupMapper
        {
                ProjectGroup MapBOToEF(
                        BOProjectGroup bo);

                BOProjectGroup MapEFToBO(
                        ProjectGroup efProjectGroup);

                List<BOProjectGroup> MapEFToBO(
                        List<ProjectGroup> records);
        }
}

/*<Codenesium>
    <Hash>370425daf6f156681af10bc7cbaa5430</Hash>
</Codenesium>*/