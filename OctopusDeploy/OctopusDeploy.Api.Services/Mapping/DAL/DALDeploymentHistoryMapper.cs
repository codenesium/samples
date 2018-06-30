using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public partial class DALDeploymentHistoryMapper : DALAbstractDeploymentHistoryMapper, IDALDeploymentHistoryMapper
        {
                public DALDeploymentHistoryMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>0fbfb19050e886ca4e47d6fc9442b10c</Hash>
</Codenesium>*/