using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class DALTenantMapper: DALAbstractTenantMapper, IDALTenantMapper
        {
                public DALTenantMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>d74225526907815acccb4ed43c3e60ab</Hash>
</Codenesium>*/