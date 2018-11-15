using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>cceab56b78920b8f43df61d51aa8b19a</Hash>
</Codenesium>*/