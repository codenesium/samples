using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public interface IDALCommunityActionTemplateMapper
        {
                CommunityActionTemplate MapBOToEF(
                        BOCommunityActionTemplate bo);

                BOCommunityActionTemplate MapEFToBO(
                        CommunityActionTemplate efCommunityActionTemplate);

                List<BOCommunityActionTemplate> MapEFToBO(
                        List<CommunityActionTemplate> records);
        }
}

/*<Codenesium>
    <Hash>948f362af4b5ae14a42f398a277854ea</Hash>
</Codenesium>*/