using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class BOLAbstractSpaceMapper
	{
		public virtual BOSpace MapModelToBO(
			int id,
			ApiSpaceRequestModel model
			)
		{
			BOSpace boSpace = new BOSpace();
			boSpace.SetProperties(
				id,
				model.Description,
				model.Name);
			return boSpace;
		}

		public virtual ApiSpaceResponseModel MapBOToModel(
			BOSpace boSpace)
		{
			var model = new ApiSpaceResponseModel();

			model.SetProperties(boSpace.Id, boSpace.Description, boSpace.Name);

			return model;
		}

		public virtual List<ApiSpaceResponseModel> MapBOToModel(
			List<BOSpace> items)
		{
			List<ApiSpaceResponseModel> response = new List<ApiSpaceResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b71e4f124a7e21f20a465301741d5971</Hash>
</Codenesium>*/