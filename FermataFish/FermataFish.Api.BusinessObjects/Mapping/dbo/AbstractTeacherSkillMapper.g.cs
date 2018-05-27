using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects
{
	public abstract class AbstractBOLTeacherSkillMapper
	{
		public virtual DTOTeacherSkill MapModelToDTO(
			int id,
			ApiTeacherSkillRequestModel model
			)
		{
			DTOTeacherSkill dtoTeacherSkill = new DTOTeacherSkill();

			dtoTeacherSkill.SetProperties(
				id,
				model.Name,
				model.StudioId);
			return dtoTeacherSkill;
		}

		public virtual ApiTeacherSkillResponseModel MapDTOToModel(
			DTOTeacherSkill dtoTeacherSkill)
		{
			if (dtoTeacherSkill == null)
			{
				return null;
			}

			var model = new ApiTeacherSkillResponseModel();

			model.SetProperties(dtoTeacherSkill.Id, dtoTeacherSkill.Name, dtoTeacherSkill.StudioId);

			return model;
		}

		public virtual List<ApiTeacherSkillResponseModel> MapDTOToModel(
			List<DTOTeacherSkill> dtos)
		{
			List<ApiTeacherSkillResponseModel> response = new List<ApiTeacherSkillResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>4be2a0966f8441475ac7cf4f7a84a933</Hash>
</Codenesium>*/