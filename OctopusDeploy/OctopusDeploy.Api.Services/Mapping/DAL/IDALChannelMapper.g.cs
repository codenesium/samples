using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IDALChannelMapper
        {
                Channel MapBOToEF(
                        BOChannel bo);

                BOChannel MapEFToBO(
                        Channel efChannel);

                List<BOChannel> MapEFToBO(
                        List<Channel> records);
        }
}

/*<Codenesium>
    <Hash>2e029441c3c9aaaf0e54bf532738320f</Hash>
</Codenesium>*/