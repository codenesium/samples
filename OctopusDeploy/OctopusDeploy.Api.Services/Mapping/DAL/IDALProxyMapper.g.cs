using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public interface IDALProxyMapper
        {
                Proxy MapBOToEF(
                        BOProxy bo);

                BOProxy MapEFToBO(
                        Proxy efProxy);

                List<BOProxy> MapEFToBO(
                        List<Proxy> records);
        }
}

/*<Codenesium>
    <Hash>9af5198e98c7c6c6e4c59da73ddf0d5b</Hash>
</Codenesium>*/