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
    <Hash>c95c3105c077fc3f4b9ceb89a100908b</Hash>
</Codenesium>*/