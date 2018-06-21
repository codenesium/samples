using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>494513daec11667fb905aa704d923b1c</Hash>
</Codenesium>*/