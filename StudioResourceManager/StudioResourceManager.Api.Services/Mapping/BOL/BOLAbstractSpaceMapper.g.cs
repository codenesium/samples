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
				model.Name,
				model.IsDeleted);
			return boSpace;
		}

		public virtual ApiSpaceResponseModel MapBOToModel(
			BOSpace boSpace)
		{
			var model = new ApiSpaceResponseModel();

			model.SetProperties(boSpace.Id, boSpace.Description, boSpace.Name, boSpace.IsDeleted);

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
    <Hash>e108d49ca2296b9f7abe45284c6f1a26</Hash>
</Codenesium>*/