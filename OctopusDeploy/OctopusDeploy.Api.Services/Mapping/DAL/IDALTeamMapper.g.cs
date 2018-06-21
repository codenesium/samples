using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>13c4d92268fb7cb8f075d5a56cd1c03a</Hash>
</Codenesium>*/