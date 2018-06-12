using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>66bcff7ba5651e527b7941efb46d9171</Hash>
</Codenesium>*/