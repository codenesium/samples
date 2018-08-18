using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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

			model.SetProperties(boArtifact.Id, boArtifact.Created, boArtifact.EnvironmentId, boArtifact.Filename, boArtifact.JSON, boArtifact.ProjectId, boArtifact.RelatedDocumentIds, boArtifact.TenantId);

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
    <Hash>4e95484c5dcb18bd6212fbe8041f48e2</Hash>
</Codenesium>*/