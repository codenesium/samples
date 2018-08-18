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
    <Hash>296d3da029459fd3d9e4b83c09459ca7</Hash>
</Codenesium>*/