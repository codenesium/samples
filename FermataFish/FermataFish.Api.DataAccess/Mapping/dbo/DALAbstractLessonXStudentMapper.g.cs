using System;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.DataAccess
{
	public abstract class AbstractDALLessonXStudentMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOLessonXStudent dto,
			LessonXStudent efLessonXStudent)
		{
			efLessonXStudent.SetProperties(
				id,
				dto.LessonId,
				dto.StudentId);
		}

		public virtual DTOLessonXStudent MapEFToDTO(
			LessonXStudent ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOLessonXStudent();

			dto.SetProperties(
				ef.Id,
				ef.LessonId,
				ef.StudentId);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>2198c45cfbbc3968c830e3925d41da0e</Hash>
</Codenesium>*/