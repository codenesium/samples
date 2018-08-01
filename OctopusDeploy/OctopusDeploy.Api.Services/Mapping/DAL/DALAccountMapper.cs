using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
	public partial class DALAccountMapper : DALAbstractAccountMapper, IDALAccountMapper
	{
		public DALAccountMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>a8f2a32d422355ae115e4dfb7ef23aea</Hash>
</Codenesium>*/