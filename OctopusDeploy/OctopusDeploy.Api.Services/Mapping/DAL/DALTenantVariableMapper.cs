using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public partial class DALTenantVariableMapper : DALAbstractTenantVariableMapper, IDALTenantVariableMapper
        {
                public DALTenantVariableMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>18226bdd488d173517cf8feb7cd4ebc7</Hash>
</Codenesium>*/