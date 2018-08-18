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
    <Hash>80465185d368e47fe021a14c58913e3e</Hash>
</Codenesium>*/