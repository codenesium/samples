using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>bce647ef305680d7b683062b1dd299ea</Hash>
</Codenesium>*/