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
    <Hash>c60702b80e119af6746f01ae88357d23</Hash>
</Codenesium>*/