using System;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.DataAccess
{
	public interface IDALLessonXStudentMapper
	{
		void MapDTOToEF(
			int id,
			DTOLessonXStudent dto,
			LessonXStudent efLessonXStudent);

		DTOLessonXStudent MapEFToDTO(
			LessonXStudent efLessonXStudent);
	}
}

/*<Codenesium>
    <Hash>c52dd256a42c0df1a5ad0c152c8a5c86</Hash>
</Codenesium>*/