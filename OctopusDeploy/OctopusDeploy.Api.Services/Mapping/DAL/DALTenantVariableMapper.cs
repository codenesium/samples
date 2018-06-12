using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class DALTenantVariableMapper: DALAbstractTenantVariableMapper, IDALTenantVariableMapper
        {
                public DALTenantVariableMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>520f1f8463d2937714a3fffed843a102</Hash>
</Codenesium>*/