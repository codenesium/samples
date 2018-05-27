using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects
{
	public abstract class AbstractBOLRateMapper
	{
		public virtual DTORate MapModelToDTO(
			int id,
			ApiRateRequestModel model
			)
		{
			DTORate dtoRate = new DTORate();

			dtoRate.SetProperties(
				id,
				model.AmountPerMinute,
				model.TeacherId,
				model.TeacherSkillId);
			return dtoRate;
		}

		public virtual ApiRateResponseModel MapDTOToModel(
			DTORate dtoRate)
		{
			if (dtoRate == null)
			{
				return null;
			}

			var model = new ApiRateResponseModel();

			model.SetProperties(dtoRate.AmountPerMinute, dtoRate.Id, dtoRate.TeacherId, dtoRate.TeacherSkillId);

			return model;
		}

		public virtual List<ApiRateResponseModel> MapDTOToModel(
			List<DTORate> dtos)
		{
			List<ApiRateResponseModel> response = new List<ApiRateResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>9a2e7dc21852096760daba7cb1d1cd40</Hash>
</Codenesium>*/