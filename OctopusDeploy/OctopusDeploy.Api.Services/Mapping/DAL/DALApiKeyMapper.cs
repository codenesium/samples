using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
	public partial class DALApiKeyMapper : DALAbstractApiKeyMapper, IDALApiKeyMapper
	{
		public DALApiKeyMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>ddd7dd025ca91d03eb6ce295c51c04dd</Hash>
</Codenesium>*/