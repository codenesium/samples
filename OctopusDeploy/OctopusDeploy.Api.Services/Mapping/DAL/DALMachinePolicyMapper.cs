using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
	public partial class DALMachinePolicyMapper : DALAbstractMachinePolicyMapper, IDALMachinePolicyMapper
	{
		public DALMachinePolicyMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>532a240caecd443c67770f5769374de3</Hash>
</Codenesium>*/