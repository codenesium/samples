using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class DALWorkerTaskLeaseMapper: DALAbstractWorkerTaskLeaseMapper, IDALWorkerTaskLeaseMapper
        {
                public DALWorkerTaskLeaseMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>ba977f35927b53a1ea4d3821130b04ee</Hash>
</Codenesium>*/