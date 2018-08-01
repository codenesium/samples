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
    <Hash>5426c11d1307ae0b9f4abdce72ca461b</Hash>
</Codenesium>*/