using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
	public partial class DALWorkerPoolMapper : DALAbstractWorkerPoolMapper, IDALWorkerPoolMapper
	{
		public DALWorkerPoolMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>0ce386ee98abf067e6e27ba8a086f6ad</Hash>
</Codenesium>*/