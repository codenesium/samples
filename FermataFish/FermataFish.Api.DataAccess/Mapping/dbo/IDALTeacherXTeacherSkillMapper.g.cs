using System;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.DataAccess
{
	public interface IDALTeacherXTeacherSkillMapper
	{
		void MapDTOToEF(
			int id,
			DTOTeacherXTeacherSkill dto,
			TeacherXTeacherSkill efTeacherXTeacherSkill);

		DTOTeacherXTeacherSkill MapEFToDTO(
			TeacherXTeacherSkill efTeacherXTeacherSkill);
	}
}

/*<Codenesium>
    <Hash>644132aa0b44c65638f41db63de724ed</Hash>
</Codenesium>*/