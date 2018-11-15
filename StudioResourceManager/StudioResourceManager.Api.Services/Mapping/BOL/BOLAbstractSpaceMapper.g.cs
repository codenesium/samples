using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class BOLAbstractSpaceMapper
	{
		public virtual BOSpace MapModelToBO(
			int id,
			ApiSpaceServerRequestModel model
			)
		{
			BOSpace boSpace = new BOSpace();
			boSpace.SetProperties(
				id,
				model.Description,
				model.Name);
			return boSpace;
		}

		public virtual ApiSpaceServerResponseModel MapBOToModel(
			BOSpace boSpace)
		{
			var model = new ApiSpaceServerResponseModel();

			model.SetProperties(boSpace.Id, boSpace.Description, boSpace.Name);

			return model;
		}

		public virtual List<ApiSpaceServerResponseModel> MapBOToModel(
			List<BOSpace> items)
		{
			List<ApiSpaceServerResponseModel> response = new List<ApiSpaceServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>3cc21298a3f069a13972b60719bdd844</Hash>
</Codenesium>*/