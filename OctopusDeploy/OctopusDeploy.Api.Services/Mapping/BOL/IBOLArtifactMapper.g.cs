using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLArtifactMapper
	{
		BOArtifact MapModelToBO(
			string id,
			ApiArtifactRequestModel model);

		ApiArtifactResponseModel MapBOToModel(
			BOArtifact boArtifact);

		List<ApiArtifactResponseModel> MapBOToModel(
			List<BOArtifact> items);
	}
}

/*<Codenesium>
    <Hash>6746629b786b8bbedf974b9268d0fb3b</Hash>
</Codenesium>*/