using System;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.DataAccess
{
	public interface IDALLessonMapper
	{
		void MapDTOToEF(
			int id,
			DTOLesson dto,
			Lesson efLesson);

		DTOLesson MapEFToDTO(
			Lesson efLesson);
	}
}

/*<Codenesium>
    <Hash>d7156586be12c10830a6e649f4d2adae</Hash>
</Codenesium>*/