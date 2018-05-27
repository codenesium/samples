using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects
{
	public abstract class AbstractBOLSpaceMapper
	{
		public virtual DTOSpace MapModelToDTO(
			int id,
			ApiSpaceRequestModel model
			)
		{
			DTOSpace dtoSpace = new DTOSpace();

			dtoSpace.SetProperties(
				id,
				model.Description,
				model.Name,
				model.StudioId);
			return dtoSpace;
		}

		public virtual ApiSpaceResponseModel MapDTOToModel(
			DTOSpace dtoSpace)
		{
			if (dtoSpace == null)
			{
				return null;
			}

			var model = new ApiSpaceResponseModel();

			model.SetProperties(dtoSpace.Description, dtoSpace.Id, dtoSpace.Name, dtoSpace.StudioId);

			return model;
		}

		public virtual List<ApiSpaceResponseModel> MapDTOToModel(
			List<DTOSpace> dtos)
		{
			List<ApiSpaceResponseModel> response = new List<ApiSpaceResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>067939be4f1108290b43227f7d17f923</Hash>
</Codenesium>*/