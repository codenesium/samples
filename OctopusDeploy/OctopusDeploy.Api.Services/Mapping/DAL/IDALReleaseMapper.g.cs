using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>8d35cd50270460dc2f24a4262f240e22</Hash>
</Codenesium>*/