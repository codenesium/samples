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
    <Hash>5eaa3be8c4abd7cdcef881cab69483ad</Hash>
</Codenesium>*/