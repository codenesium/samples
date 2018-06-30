using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>e8589c260d2ea51a645191752e4f7c88</Hash>
</Codenesium>*/