using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
	public partial class DALKeyAllocationMapper : DALAbstractKeyAllocationMapper, IDALKeyAllocationMapper
	{
		public DALKeyAllocationMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>5ea2c6c7dd48d49690de06fcd1aac285</Hash>
</Codenesium>*/