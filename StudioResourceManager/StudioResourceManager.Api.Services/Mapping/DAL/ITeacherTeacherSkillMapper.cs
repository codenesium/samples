using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IDALTeacherTeacherSkillMapper
	{
		TeacherTeacherSkill MapModelToEntity(
			int id,
			ApiTeacherTeacherSkillServerRequestModel model);

		ApiTeacherTeacherSkillServerResponseModel MapEntityToModel(
			TeacherTeacherSkill item);

		List<ApiTeacherTeacherSkillServerResponseModel> MapEntityToModel(
			List<TeacherTeacherSkill> items);
	}
}

/*<Codenesium>
    <Hash>f938efd5e3786fd9d223094d229943ae</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/