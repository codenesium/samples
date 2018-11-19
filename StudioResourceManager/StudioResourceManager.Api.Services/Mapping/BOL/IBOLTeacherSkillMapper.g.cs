using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IBOLTeacherSkillMapper
	{
		BOTeacherSkill MapModelToBO(
			int id,
			ApiTeacherSkillServerRequestModel model);

		ApiTeacherSkillServerResponseModel MapBOToModel(
			BOTeacherSkill boTeacherSkill);

		List<ApiTeacherSkillServerResponseModel> MapBOToModel(
			List<BOTeacherSkill> items);
	}
}

/*<Codenesium>
    <Hash>ae34fe3a3ac5acbbee0473dc20a6eafc</Hash>
</Codenesium>*/