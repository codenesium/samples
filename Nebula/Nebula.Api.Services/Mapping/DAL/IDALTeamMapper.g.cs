using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
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
    <Hash>d1044a9036acd65cd00ec41cb4876849</Hash>
</Codenesium>*/