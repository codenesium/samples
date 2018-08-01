using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
	public partial class DALMutexMapper : DALAbstractMutexMapper, IDALMutexMapper
	{
		public DALMutexMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>8d5c797cc2876f14de3eccd6c88cbf26</Hash>
</Codenesium>*/