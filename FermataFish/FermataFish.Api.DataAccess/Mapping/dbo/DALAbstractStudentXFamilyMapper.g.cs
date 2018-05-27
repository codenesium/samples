using System;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.DataAccess
{
	public abstract class AbstractDALStudentXFamilyMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOStudentXFamily dto,
			StudentXFamily efStudentXFamily)
		{
			efStudentXFamily.SetProperties(
				id,
				dto.FamilyId,
				dto.StudentId);
		}

		public virtual DTOStudentXFamily MapEFToDTO(
			StudentXFamily ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOStudentXFamily();

			dto.SetProperties(
				ef.Id,
				ef.FamilyId,
				ef.StudentId);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>121ada770287692ae69cb4c8ad349e86</Hash>
</Codenesium>*/