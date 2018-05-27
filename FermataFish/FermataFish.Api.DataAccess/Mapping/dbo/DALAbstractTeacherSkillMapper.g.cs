using System;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.DataAccess
{
	public abstract class AbstractDALTeacherSkillMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOTeacherSkill dto,
			TeacherSkill efTeacherSkill)
		{
			efTeacherSkill.SetProperties(
				id,
				dto.Name,
				dto.StudioId);
		}

		public virtual DTOTeacherSkill MapEFToDTO(
			TeacherSkill ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOTeacherSkill();

			dto.SetProperties(
				ef.Id,
				ef.Name,
				ef.StudioId);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>8a8337bbf41aa6586039e7ce41ed7821</Hash>
</Codenesium>*/