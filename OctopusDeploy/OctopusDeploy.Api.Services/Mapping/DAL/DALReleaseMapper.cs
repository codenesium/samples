using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
	public partial class DALReleaseMapper : DALAbstractReleaseMapper, IDALReleaseMapper
	{
		public DALReleaseMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>a6ee0277c7a1176a425369d86a7dda91</Hash>
</Codenesium>*/