using System;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.DataAccess
{
	public interface IDALTeacherSkillMapper
	{
		void MapDTOToEF(
			int id,
			DTOTeacherSkill dto,
			TeacherSkill efTeacherSkill);

		DTOTeacherSkill MapEFToDTO(
			TeacherSkill efTeacherSkill);
	}
}

/*<Codenesium>
    <Hash>c7b0ec33c2e3286e9bf768b7f6814921</Hash>
</Codenesium>*/