using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class BOLAbstractActionTemplateVersionMapper
	{
		public virtual BOActionTemplateVersion MapModelToBO(
			string id,
			ApiActionTemplateVersionRequestModel model
			)
		{
			BOActionTemplateVersion boActionTemplateVersion = new BOActionTemplateVersion();
			boActionTemplateVersion.SetProperties(
				id,
				model.ActionType,
				model.JSON,
				model.LatestActionTemplateId,
				model.Name,
				model.Version);
			return boActionTemplateVersion;
		}

		public virtual ApiActionTemplateVersionResponseModel MapBOToModel(
			BOActionTemplateVersion boActionTemplateVersion)
		{
			var model = new ApiActionTemplateVersionResponseModel();

			model.SetProperties(boActionTemplateVersion.Id, boActionTemplateVersion.ActionType, boActionTemplateVersion.JSON, boActionTemplateVersion.LatestActionTemplateId, boActionTemplateVersion.Name, boActionTemplateVersion.Version);

			return model;
		}

		public virtual List<ApiActionTemplateVersionResponseModel> MapBOToModel(
			List<BOActionTemplateVersion> items)
		{
			List<ApiActionTemplateVersionResponseModel> response = new List<ApiActionTemplateVersionResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>8c7f7b8d2079dfe9083bd09b9aba6c9a</Hash>
</Codenesium>*/