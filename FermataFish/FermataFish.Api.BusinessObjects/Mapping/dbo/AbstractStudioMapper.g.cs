using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects
{
	public abstract class AbstractBOLStudioMapper
	{
		public virtual DTOStudio MapModelToDTO(
			int id,
			ApiStudioRequestModel model
			)
		{
			DTOStudio dtoStudio = new DTOStudio();

			dtoStudio.SetProperties(
				id,
				model.Address1,
				model.Address2,
				model.City,
				model.Name,
				model.StateId,
				model.Website,
				model.Zip);
			return dtoStudio;
		}

		public virtual ApiStudioResponseModel MapDTOToModel(
			DTOStudio dtoStudio)
		{
			if (dtoStudio == null)
			{
				return null;
			}

			var model = new ApiStudioResponseModel();

			model.SetProperties(dtoStudio.Address1, dtoStudio.Address2, dtoStudio.City, dtoStudio.Id, dtoStudio.Name, dtoStudio.StateId, dtoStudio.Website, dtoStudio.Zip);

			return model;
		}

		public virtual List<ApiStudioResponseModel> MapDTOToModel(
			List<DTOStudio> dtos)
		{
			List<ApiStudioResponseModel> response = new List<ApiStudioResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f9e318936e677fa57ebe95ce1c47638c</Hash>
</Codenesium>*/