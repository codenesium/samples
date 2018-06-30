using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>b78611e32d0d06d1c85cfed39942dd89</Hash>
</Codenesium>*/