using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOLTeacherXTeacherSkillMapper
	{
		DTOTeacherXTeacherSkill MapModelToDTO(
			int id,
			ApiTeacherXTeacherSkillRequestModel model);

		ApiTeacherXTeacherSkillResponseModel MapDTOToModel(
			DTOTeacherXTeacherSkill dtoTeacherXTeacherSkill);

		List<ApiTeacherXTeacherSkillResponseModel> MapDTOToModel(
			List<DTOTeacherXTeacherSkill> dtos);
	}
}

/*<Codenesium>
    <Hash>f6426970a7ab1efaefe622aaf7193c81</Hash>
</Codenesium>*/