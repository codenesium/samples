using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
	public partial class DALWorkerTaskLeaseMapper : DALAbstractWorkerTaskLeaseMapper, IDALWorkerTaskLeaseMapper
	{
		public DALWorkerTaskLeaseMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>8177aa4d2c3f342abbc529d5a2ec7f43</Hash>
</Codenesium>*/