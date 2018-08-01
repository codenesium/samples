using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
	public partial class DALServerTaskMapper : DALAbstractServerTaskMapper, IDALServerTaskMapper
	{
		public DALServerTaskMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>1474f81848419e010650dec40c180a19</Hash>
</Codenesium>*/