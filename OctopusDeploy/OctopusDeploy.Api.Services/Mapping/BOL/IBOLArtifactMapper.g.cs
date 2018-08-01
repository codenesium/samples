using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IBOLArtifactMapper
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
    <Hash>6c2220c1b49621d939abf52affc05737</Hash>
</Codenesium>*/