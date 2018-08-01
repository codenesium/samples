using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class BOLAbstractProjectGroupMapper
	{
		public virtual BOProjectGroup MapModelToBO(
			string id,
			ApiProjectGroupRequestModel model
			)
		{
			BOProjectGroup boProjectGroup = new BOProjectGroup();
			boProjectGroup.SetProperties(
				id,
				model.DataVersion,
				model.JSON,
				model.Name);
			return boProjectGroup;
		}

		public virtual ApiProjectGroupResponseModel MapBOToModel(
			BOProjectGroup boProjectGroup)
		{
			var model = new ApiProjectGroupResponseModel();

			model.SetProperties(boProjectGroup.Id, boProjectGroup.DataVersion, boProjectGroup.JSON, boProjectGroup.Name);

			return model;
		}

		public virtual List<ApiProjectGroupResponseModel> MapBOToModel(
			List<BOProjectGroup> items)
		{
			List<ApiProjectGroupResponseModel> response = new List<ApiProjectGroupResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>96f79d5edfca7bd28f3d7458d1acb9ce</Hash>
</Codenesium>*/