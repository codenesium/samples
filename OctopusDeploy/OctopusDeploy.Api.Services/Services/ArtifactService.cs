using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial class ArtifactService : AbstractArtifactService, IArtifactService
	{
		public ArtifactService(
			ILogger<IArtifactRepository> logger,
			IArtifactRepository artifactRepository,
			IApiArtifactRequestModelValidator artifactModelValidator,
			IBOLArtifactMapper bolartifactMapper,
			IDALArtifactMapper dalartifactMapper
			)
			: base(logger,
			       artifactRepository,
			       artifactModelValidator,
			       bolartifactMapper,
			       dalartifactMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>93969d4d3f7213146b41291ea4c30806</Hash>
</Codenesium>*/