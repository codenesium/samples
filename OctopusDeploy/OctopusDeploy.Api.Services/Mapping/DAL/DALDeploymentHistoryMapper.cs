using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class DALDeploymentHistoryMapper: DALAbstractDeploymentHistoryMapper, IDALDeploymentHistoryMapper
        {
                public DALDeploymentHistoryMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>8256278b8cae6759d041da9b5d68003a</Hash>
</Codenesium>*/