using System;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.DataAccess
{
	public abstract class AbstractDALTeacherMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOTeacher dto,
			Teacher efTeacher)
		{
			efTeacher.SetProperties(
				id,
				dto.Birthday,
				dto.Email,
				dto.FirstName,
				dto.LastName,
				dto.Phone,
				dto.StudioId);
		}

		public virtual DTOTeacher MapEFToDTO(
			Teacher ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOTeacher();

			dto.SetProperties(
				ef.Id,
				ef.Birthday,
				ef.Email,
				ef.FirstName,
				ef.LastName,
				ef.Phone,
				ef.StudioId);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>7e6b930db434dcedda01d0d7d75d7ff0</Hash>
</Codenesium>*/