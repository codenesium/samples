using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class BOLAbstractProjectTriggerMapper
	{
		public virtual BOProjectTrigger MapModelToBO(
			string id,
			ApiProjectTriggerRequestModel model
			)
		{
			BOProjectTrigger boProjectTrigger = new BOProjectTrigger();
			boProjectTrigger.SetProperties(
				id,
				model.IsDisabled,
				model.JSON,
				model.Name,
				model.ProjectId,
				model.TriggerType);
			return boProjectTrigger;
		}

		public virtual ApiProjectTriggerResponseModel MapBOToModel(
			BOProjectTrigger boProjectTrigger)
		{
			var model = new ApiProjectTriggerResponseModel();

			model.SetProperties(boProjectTrigger.Id, boProjectTrigger.IsDisabled, boProjectTrigger.JSON, boProjectTrigger.Name, boProjectTrigger.ProjectId, boProjectTrigger.TriggerType);

			return model;
		}

		public virtual List<ApiProjectTriggerResponseModel> MapBOToModel(
			List<BOProjectTrigger> items)
		{
			List<ApiProjectTriggerResponseModel> response = new List<ApiProjectTriggerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>4154b46299f55e779df9ae33969f3266</Hash>
</Codenesium>*/