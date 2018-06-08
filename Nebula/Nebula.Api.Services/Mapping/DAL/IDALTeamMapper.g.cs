using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

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
    <Hash>7c4c0e1aaa6fd9da1ef7ebd64916d57e</Hash>
</Codenesium>*/