using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALArtifactMapper
	{
		Artifact MapBOToEF(
			BOArtifact bo);

		BOArtifact MapEFToBO(
			Artifact efArtifact);

		List<BOArtifact> MapEFToBO(
			List<Artifact> records);
	}
}

/*<Codenesium>
    <Hash>730f73a713301e8ca0e307452705bef6</Hash>
</Codenesium>*/