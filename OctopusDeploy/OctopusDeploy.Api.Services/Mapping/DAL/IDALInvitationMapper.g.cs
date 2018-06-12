using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IDALInvitationMapper
        {
                Invitation MapBOToEF(
                        BOInvitation bo);

                BOInvitation MapEFToBO(
                        Invitation efInvitation);

                List<BOInvitation> MapEFToBO(
                        List<Invitation> records);
        }
}

/*<Codenesium>
    <Hash>4fea0424ae61c0b36a5596db26e51617</Hash>
</Codenesium>*/