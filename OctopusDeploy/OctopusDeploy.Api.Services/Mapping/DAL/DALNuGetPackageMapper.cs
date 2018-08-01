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
    <Hash>04139825cf47006376fb12cd73484381</Hash>
</Codenesium>*/