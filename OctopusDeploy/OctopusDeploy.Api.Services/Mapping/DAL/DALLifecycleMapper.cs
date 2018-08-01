using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
	public partial class DALLifecycleMapper : DALAbstractLifecycleMapper, IDALLifecycleMapper
	{
		public DALLifecycleMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>32f2723a5022a4d1f3273b4fbb9a0596</Hash>
</Codenesium>*/