using System;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.DataAccess
{
	public interface IDALLessonXTeacherMapper
	{
		void MapDTOToEF(
			int id,
			DTOLessonXTeacher dto,
			LessonXTeacher efLessonXTeacher);

		DTOLessonXTeacher MapEFToDTO(
			LessonXTeacher efLessonXTeacher);
	}
}

/*<Codenesium>
    <Hash>2cfab63e749edab43ec3545cf018da36</Hash>
</Codenesium>*/