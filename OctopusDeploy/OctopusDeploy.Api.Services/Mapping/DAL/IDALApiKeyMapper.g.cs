using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>4866a346d3e3ee5523e9dfdd956dc6ce</Hash>
</Codenesium>*/