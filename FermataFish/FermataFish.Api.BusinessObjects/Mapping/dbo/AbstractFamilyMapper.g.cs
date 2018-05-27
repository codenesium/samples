using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects
{
	public abstract class AbstractBOLFamilyMapper
	{
		public virtual DTOFamily MapModelToDTO(
			int id,
			ApiFamilyRequestModel model
			)
		{
			DTOFamily dtoFamily = new DTOFamily();

			dtoFamily.SetProperties(
				id,
				model.Notes,
				model.PcEmail,
				model.PcFirstName,
				model.PcLastName,
				model.PcPhone,
				model.StudioId);
			return dtoFamily;
		}

		public virtual ApiFamilyResponseModel MapDTOToModel(
			DTOFamily dtoFamily)
		{
			if (dtoFamily == null)
			{
				return null;
			}

			var model = new ApiFamilyResponseModel();

			model.SetProperties(dtoFamily.Id, dtoFamily.Notes, dtoFamily.PcEmail, dtoFamily.PcFirstName, dtoFamily.PcLastName, dtoFamily.PcPhone, dtoFamily.StudioId);

			return model;
		}

		public virtual List<ApiFamilyResponseModel> MapDTOToModel(
			List<DTOFamily> dtos)
		{
			List<ApiFamilyResponseModel> response = new List<ApiFamilyResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>331a4943394777bbc7ebc44b3fb08169</Hash>
</Codenesium>*/