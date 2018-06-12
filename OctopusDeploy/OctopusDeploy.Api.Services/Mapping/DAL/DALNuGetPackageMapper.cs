using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class DALNuGetPackageMapper: DALAbstractNuGetPackageMapper, IDALNuGetPackageMapper
        {
                public DALNuGetPackageMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>996e5e3005e8a56938beb8f715b49c02</Hash>
</Codenesium>*/