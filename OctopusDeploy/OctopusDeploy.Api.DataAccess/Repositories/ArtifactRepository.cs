using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial class ArtifactRepository : AbstractArtifactRepository, IArtifactRepository
	{
		public ArtifactRepository(
			ILogger<ArtifactRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>640b8c83a419fadf04c91a8e4c57c56b</Hash>
</Codenesium>*/