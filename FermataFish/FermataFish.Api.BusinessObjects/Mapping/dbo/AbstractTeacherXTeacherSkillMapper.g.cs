using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects
{
	public abstract class AbstractBOLTeacherXTeacherSkillMapper
	{
		public virtual DTOTeacherXTeacherSkill MapModelToDTO(
			int id,
			ApiTeacherXTeacherSkillRequestModel model
			)
		{
			DTOTeacherXTeacherSkill dtoTeacherXTeacherSkill = new DTOTeacherXTeacherSkill();

			dtoTeacherXTeacherSkill.SetProperties(
				id,
				model.TeacherId,
				model.TeacherSkillId);
			return dtoTeacherXTeacherSkill;
		}

		public virtual ApiTeacherXTeacherSkillResponseModel MapDTOToModel(
			DTOTeacherXTeacherSkill dtoTeacherXTeacherSkill)
		{
			if (dtoTeacherXTeacherSkill == null)
			{
				return null;
			}

			var model = new ApiTeacherXTeacherSkillResponseModel();

			model.SetProperties(dtoTeacherXTeacherSkill.Id, dtoTeacherXTeacherSkill.TeacherId, dtoTeacherXTeacherSkill.TeacherSkillId);

			return model;
		}

		public virtual List<ApiTeacherXTeacherSkillResponseModel> MapDTOToModel(
			List<DTOTeacherXTeacherSkill> dtos)
		{
			List<ApiTeacherXTeacherSkillResponseModel> response = new List<ApiTeacherXTeacherSkillResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>da4fd698aeb459ec6787c9f0ff745e6e</Hash>
</Codenesium>*/