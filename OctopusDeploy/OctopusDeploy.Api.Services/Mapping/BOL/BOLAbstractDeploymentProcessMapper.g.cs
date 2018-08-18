using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class BOLAbstractDeploymentProcessMapper
	{
		public virtual BODeploymentProcess MapModelToBO(
			string id,
			ApiDeploymentProcessRequestModel model
			)
		{
			BODeploymentProcess boDeploymentProcess = new BODeploymentProcess();
			boDeploymentProcess.SetProperties(
				id,
				model.IsFrozen,
				model.JSON,
				model.OwnerId,
				model.RelatedDocumentIds,
				model.Version);
			return boDeploymentProcess;
		}

		public virtual ApiDeploymentProcessResponseModel MapBOToModel(
			BODeploymentProcess boDeploymentProcess)
		{
			var model = new ApiDeploymentProcessResponseModel();

			model.SetProperties(boDeploymentProcess.Id, boDeploymentProcess.IsFrozen, boDeploymentProcess.JSON, boDeploymentProcess.OwnerId, boDeploymentProcess.RelatedDocumentIds, boDeploymentProcess.Version);

			return model;
		}

		public virtual List<ApiDeploymentProcessResponseModel> MapBOToModel(
			List<BODeploymentProcess> items)
		{
			List<ApiDeploymentProcessResponseModel> response = new List<ApiDeploymentProcessResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a3cd8bb4eab8cb51c9bc61536dda6d8c</Hash>
</Codenesium>*/