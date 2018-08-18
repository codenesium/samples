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
    <Hash>9f62ef58530a752ebcf119e6292d0578</Hash>
</Codenesium>*/