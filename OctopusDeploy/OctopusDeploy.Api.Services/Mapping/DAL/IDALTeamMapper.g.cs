using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IDALTeamMapper
        {
                Team MapBOToEF(
                        BOTeam bo);

                BOTeam MapEFToBO(
                        Team efTeam);

                List<BOTeam> MapEFToBO(
                        List<Team> records);
        }
}

/*<Codenesium>
    <Hash>4cb85b1a20a692f9f21ae6e701b7420e</Hash>
</Codenesium>*/