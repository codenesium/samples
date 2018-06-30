using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public partial class DALNuGetPackageMapper : DALAbstractNuGetPackageMapper, IDALNuGetPackageMapper
        {
                public DALNuGetPackageMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>d68a7d7d3ecb49a9715a530002b2353b</Hash>
</Codenesium>*/