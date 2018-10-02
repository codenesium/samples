using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public abstract class BOLAbstractSysdiagramMapper
	{
		public virtual BOSysdiagram MapModelToBO(
			int diagramId,
			ApiSysdiagramRequestModel model
			)
		{
			BOSysdiagram boSysdiagram = new BOSysdiagram();
			boSysdiagram.SetProperties(
				diagramId,
				model.Definition,
				model.Name,
				model.PrincipalId,
				model.Version);
			return boSysdiagram;
		}

		public virtual ApiSysdiagramResponseModel MapBOToModel(
			BOSysdiagram boSysdiagram)
		{
			var model = new ApiSysdiagramResponseModel();

			model.SetProperties(boSysdiagram.DiagramId, boSysdiagram.Definition, boSysdiagram.Name, boSysdiagram.PrincipalId, boSysdiagram.Version);

			return model;
		}

		public virtual List<ApiSysdiagramResponseModel> MapBOToModel(
			List<BOSysdiagram> items)
		{
			List<ApiSysdiagramResponseModel> response = new List<ApiSysdiagramResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e9c762ea57d3541a3890e61196ecb866</Hash>
</Codenesium>*/