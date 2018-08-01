using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>3d2a6c99852f1ccca8d3e00f40e9c022</Hash>
</Codenesium>*/