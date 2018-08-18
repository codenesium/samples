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
    <Hash>41d90095c62ae22f2c5e015958ecf7de</Hash>
</Codenesium>*/