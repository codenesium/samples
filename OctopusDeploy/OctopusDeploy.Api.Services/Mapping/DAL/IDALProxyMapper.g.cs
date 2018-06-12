using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>0821e5674880e91da289d9112c41aac4</Hash>
</Codenesium>*/