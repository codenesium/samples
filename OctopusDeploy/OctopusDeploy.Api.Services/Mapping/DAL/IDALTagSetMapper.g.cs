using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>d8a899aa8bef09876ed3e4c24c6704f4</Hash>
</Codenesium>*/