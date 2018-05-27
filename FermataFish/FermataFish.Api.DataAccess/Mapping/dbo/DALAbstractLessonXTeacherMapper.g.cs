using System;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.DataAccess
{
	public abstract class AbstractDALLessonXTeacherMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOLessonXTeacher dto,
			LessonXTeacher efLessonXTeacher)
		{
			efLessonXTeacher.SetProperties(
				id,
				dto.LessonId,
				dto.StudentId);
		}

		public virtual DTOLessonXTeacher MapEFToDTO(
			LessonXTeacher ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOLessonXTeacher();

			dto.SetProperties(
				ef.Id,
				ef.LessonId,
				ef.StudentId);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>7d7dbc035113f7106f1acf8734e8cce0</Hash>
</Codenesium>*/