using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>bf0068c88f3dd870cea93f61b40f33a6</Hash>
</Codenesium>*/