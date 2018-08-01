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
    <Hash>f2195e696e93b3fa19c3c235d6cc424f</Hash>
</Codenesium>*/