using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public partial class DALTenantMapper : DALAbstractTenantMapper, IDALTenantMapper
        {
                public DALTenantMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>e1fab76f2fb4aab066a7ca4999eeac1f</Hash>
</Codenesium>*/