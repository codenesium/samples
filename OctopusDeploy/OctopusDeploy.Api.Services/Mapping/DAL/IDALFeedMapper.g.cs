using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public interface IDALFeedMapper
        {
                Feed MapBOToEF(
                        BOFeed bo);

                BOFeed MapEFToBO(
                        Feed efFeed);

                List<BOFeed> MapEFToBO(
                        List<Feed> records);
        }
}

/*<Codenesium>
    <Hash>8b7c98cbf5131ff861158c41231f6066</Hash>
</Codenesium>*/