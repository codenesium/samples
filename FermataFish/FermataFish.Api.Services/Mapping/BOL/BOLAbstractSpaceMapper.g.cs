using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.Services
{
	public abstract class BOLAbstractSpaceMapper
	{
		public virtual BOSpace MapModelToBO(
			int id,
			ApiSpaceRequestModel model
			)
		{
			BOSpace BOSpace = new BOSpace();

			BOSpace.SetProperties(
				id,
				model.Description,
				model.Name,
				model.StudioId);
			return BOSpace;
		}

		public virtual ApiSpaceResponseModel MapBOToModel(
			BOSpace BOSpace)
		{
			if (BOSpace == null)
			{
				return null;
			}

			var model = new ApiSpaceResponseModel();

			model.SetProperties(BOSpace.Description, BOSpace.Id, BOSpace.Name, BOSpace.StudioId);

			return model;
		}

		public virtual List<ApiSpaceResponseModel> MapBOToModel(
			List<BOSpace> BOs)
		{
			List<ApiSpaceResponseModel> response = new List<ApiSpaceResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>38cb40d36b74e1145bf990212f2e56a3</Hash>
</Codenesium>*/