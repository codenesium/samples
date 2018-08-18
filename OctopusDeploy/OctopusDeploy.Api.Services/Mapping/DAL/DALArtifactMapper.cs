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
    <Hash>ef99d84e84b4a6d6644376ec48abc92f</Hash>
</Codenesium>*/