using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
	public partial class DALMachineMapper : DALAbstractMachineMapper, IDALMachineMapper
	{
		public DALMachineMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>ae72dd94298178c028445e37a0de6715</Hash>
</Codenesium>*/