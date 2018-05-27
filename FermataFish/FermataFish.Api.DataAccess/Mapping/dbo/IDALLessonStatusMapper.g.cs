using System;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.DataAccess
{
	public interface IDALLessonStatusMapper
	{
		void MapDTOToEF(
			int id,
			DTOLessonStatus dto,
			LessonStatus efLessonStatus);

		DTOLessonStatus MapEFToDTO(
			LessonStatus efLessonStatus);
	}
}

/*<Codenesium>
    <Hash>f0c0891067206ef30849289e3359c976</Hash>
</Codenesium>*/