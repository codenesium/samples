using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class DALWorkerTaskLeaseMapper : DALAbstractWorkerTaskLeaseMapper, IDALWorkerTaskLeaseMapper
        {
                public DALWorkerTaskLeaseMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>368ddd6623a77b22e43842bd5a17f487</Hash>
</Codenesium>*/