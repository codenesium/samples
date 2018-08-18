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
    <Hash>f46786733da43aea589cc05c409f625e</Hash>
</Codenesium>*/