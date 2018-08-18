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
    <Hash>864e97e88f0c7405e368d5952bd40a21</Hash>
</Codenesium>*/