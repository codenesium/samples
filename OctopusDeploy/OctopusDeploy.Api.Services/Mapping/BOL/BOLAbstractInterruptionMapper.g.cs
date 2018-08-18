using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class BOLAbstractInterruptionMapper
	{
		public virtual BOInterruption MapModelToBO(
			string id,
			ApiInterruptionRequestModel model
			)
		{
			BOInterruption boInterruption = new BOInterruption();
			boInterruption.SetProperties(
				id,
				model.Created,
				model.EnvironmentId,
				model.JSON,
				model.ProjectId,
				model.RelatedDocumentIds,
				model.ResponsibleTeamIds,
				model.Status,
				model.TaskId,
				model.TenantId,
				model.Title);
			return boInterruption;
		}

		public virtual ApiInterruptionResponseModel MapBOToModel(
			BOInterruption boInterruption)
		{
			var model = new ApiInterruptionResponseModel();

			model.SetProperties(boInterruption.Id, boInterruption.Created, boInterruption.EnvironmentId, boInterruption.JSON, boInterruption.ProjectId, boInterruption.RelatedDocumentIds, boInterruption.ResponsibleTeamIds, boInterruption.Status, boInterruption.TaskId, boInterruption.TenantId, boInterruption.Title);

			return model;
		}

		public virtual List<ApiInterruptionResponseModel> MapBOToModel(
			List<BOInterruption> items)
		{
			List<ApiInterruptionResponseModel> response = new List<ApiInterruptionResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c90b2b5006cb4bf5245ab54bf8245be4</Hash>
</Codenesium>*/