using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>940d84c99d61b098df7a05c90beb360e</Hash>
</Codenesium>*/