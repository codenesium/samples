using System;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.DataAccess
{
	public abstract class AbstractDALTeacherXTeacherSkillMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOTeacherXTeacherSkill dto,
			TeacherXTeacherSkill efTeacherXTeacherSkill)
		{
			efTeacherXTeacherSkill.SetProperties(
				id,
				dto.TeacherId,
				dto.TeacherSkillId);
		}

		public virtual DTOTeacherXTeacherSkill MapEFToDTO(
			TeacherXTeacherSkill ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOTeacherXTeacherSkill();

			dto.SetProperties(
				ef.Id,
				ef.TeacherId,
				ef.TeacherSkillId);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>97542122ce14c2563f7de6ed6d989649</Hash>
</Codenesium>*/