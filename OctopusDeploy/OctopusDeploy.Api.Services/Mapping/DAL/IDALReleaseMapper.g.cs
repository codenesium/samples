using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public interface IDALReleaseMapper
        {
                Release MapBOToEF(
                        BORelease bo);

                BORelease MapEFToBO(
                        Release efRelease);

                List<BORelease> MapEFToBO(
                        List<Release> records);
        }
}

/*<Codenesium>
    <Hash>67a9fb1e64936a6d168f946cd52297e7</Hash>
</Codenesium>*/