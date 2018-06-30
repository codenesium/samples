using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public partial class DALDeploymentMapper : DALAbstractDeploymentMapper, IDALDeploymentMapper
        {
                public DALDeploymentMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>2c66e3a58f8c259938d346b82d138039</Hash>
</Codenesium>*/