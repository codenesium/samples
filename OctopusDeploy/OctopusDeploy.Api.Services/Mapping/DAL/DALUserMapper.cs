using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
	public partial class DALUserMapper : DALAbstractUserMapper, IDALUserMapper
	{
		public DALUserMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>e5e3435c5f577f543dd7eaf09931fcda</Hash>
</Codenesium>*/