using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public partial class DALWorkerTaskLeaseMapper : DALAbstractWorkerTaskLeaseMapper, IDALWorkerTaskLeaseMapper
        {
                public DALWorkerTaskLeaseMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>b24fb4ab4fa5a906529d8645bedb7b01</Hash>
</Codenesium>*/