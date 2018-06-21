using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public interface IDALApiKeyMapper
        {
                ApiKey MapBOToEF(
                        BOApiKey bo);

                BOApiKey MapEFToBO(
                        ApiKey efApiKey);

                List<BOApiKey> MapEFToBO(
                        List<ApiKey> records);
        }
}

/*<Codenesium>
    <Hash>7c5da65fe042737762340111352a665f</Hash>
</Codenesium>*/