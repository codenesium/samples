using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
	public partial class DALArtifactMapper : DALAbstractArtifactMapper, IDALArtifactMapper
	{
		public DALArtifactMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>4bc11c195819deecf5858ecf0ce5e147</Hash>
</Codenesium>*/