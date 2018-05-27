using System;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.DataAccess
{
	public abstract class AbstractDALRateMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTORate dto,
			Rate efRate)
		{
			efRate.SetProperties(
				id,
				dto.AmountPerMinute,
				dto.TeacherId,
				dto.TeacherSkillId);
		}

		public virtual DTORate MapEFToDTO(
			Rate ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTORate();

			dto.SetProperties(
				ef.Id,
				ef.AmountPerMinute,
				ef.TeacherId,
				ef.TeacherSkillId);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>1405af060e58bee97a5a3a0713dd1fc6</Hash>
</Codenesium>*/