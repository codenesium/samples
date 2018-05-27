using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOLTeacherSkillMapper
	{
		DTOTeacherSkill MapModelToDTO(
			int id,
			ApiTeacherSkillRequestModel model);

		ApiTeacherSkillResponseModel MapDTOToModel(
			DTOTeacherSkill dtoTeacherSkill);

		List<ApiTeacherSkillResponseModel> MapDTOToModel(
			List<DTOTeacherSkill> dtos);
	}
}

/*<Codenesium>
    <Hash>c19b0e5448e6692671dd9f8f9231303f</Hash>
</Codenesium>*/