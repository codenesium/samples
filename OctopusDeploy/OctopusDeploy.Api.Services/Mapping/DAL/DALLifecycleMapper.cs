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
    <Hash>3c3a24c582c396899b2c5c4cbb7a118e</Hash>
</Codenesium>*/