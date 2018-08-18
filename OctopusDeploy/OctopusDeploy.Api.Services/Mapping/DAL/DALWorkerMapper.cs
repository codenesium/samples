using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
	public partial class DALWorkerMapper : DALAbstractWorkerMapper, IDALWorkerMapper
	{
		public DALWorkerMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>52659a85ab6bff059d2661e6e12fefe7</Hash>
</Codenesium>*/