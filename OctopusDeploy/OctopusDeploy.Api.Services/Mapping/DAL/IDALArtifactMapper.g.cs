using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IDALArtifactMapper
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
    <Hash>3361ce88f70880e39e03b607bf0a916f</Hash>
</Codenesium>*/