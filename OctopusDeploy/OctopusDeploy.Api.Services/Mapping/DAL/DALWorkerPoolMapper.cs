using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class DALWorkerPoolMapper: DALAbstractWorkerPoolMapper, IDALWorkerPoolMapper
        {
                public DALWorkerPoolMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>f046292c4711cb6c3ecf7464c44a57c4</Hash>
</Codenesium>*/