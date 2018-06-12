using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IDALOctopusServerNodeMapper
        {
                OctopusServerNode MapBOToEF(
                        BOOctopusServerNode bo);

                BOOctopusServerNode MapEFToBO(
                        OctopusServerNode efOctopusServerNode);

                List<BOOctopusServerNode> MapEFToBO(
                        List<OctopusServerNode> records);
        }
}

/*<Codenesium>
    <Hash>8d9f39dafba5cd1ffe1b17543731da90</Hash>
</Codenesium>*/