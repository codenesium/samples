using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public interface IDALTagSetMapper
        {
                TagSet MapBOToEF(
                        BOTagSet bo);

                BOTagSet MapEFToBO(
                        TagSet efTagSet);

                List<BOTagSet> MapEFToBO(
                        List<TagSet> records);
        }
}

/*<Codenesium>
    <Hash>baef67678a909755d3d9a6adb13385af</Hash>
</Codenesium>*/