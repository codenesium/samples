using System;
using System.Collections.Generic;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>6bd0063635b193c8ca9f43f997de00d1</Hash>
</Codenesium>*/