using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class DALProxyMapper: DALAbstractProxyMapper, IDALProxyMapper
        {
                public DALProxyMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>327cb8ee26fd8771b3b40d3546398905</Hash>
</Codenesium>*/