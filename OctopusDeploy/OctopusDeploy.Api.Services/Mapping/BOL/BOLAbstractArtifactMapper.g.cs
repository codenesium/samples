using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class BOLAbstractArtifactMapper
        {
                public virtual BOArtifact MapModelToBO(
                        string id,
                        ApiArtifactRequestModel model
                        )
                {
                        BOArtifact boArtifact = new BOArtifact();

                        boArtifact.SetProperties(
                                id,
                                model.Created,
                                model.EnvironmentId,
                                model.Filename,
                                model.JSON,
                                model.ProjectId,
                                model.RelatedDocumentIds,
                                model.TenantId);
                        return boArtifact;
                }

                public virtual ApiArtifactResponseModel MapBOToModel(
                        BOArtifact boArtifact)
                {
                        var model = new ApiArtifactResponseModel();

                        model.SetProperties(boArtifact.Created, boArtifact.EnvironmentId, boArtifact.Filename, boArtifact.Id, boArtifact.JSON, boArtifact.ProjectId, boArtifact.RelatedDocumentIds, boArtifact.TenantId);

                        return model;
                }

                public virtual List<ApiArtifactResponseModel> MapBOToModel(
                        List<BOArtifact> items)
                {
                        List<ApiArtifactResponseModel> response = new List<ApiArtifactResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>d6084dad7ff16d8913d02ab4de12d56c</Hash>
</Codenesium>*/