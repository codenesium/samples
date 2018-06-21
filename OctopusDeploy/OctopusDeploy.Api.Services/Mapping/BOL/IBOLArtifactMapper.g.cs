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
    <Hash>f06acb1a65d71941901484deb769cdde</Hash>
</Codenesium>*/