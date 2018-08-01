using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public interface IDALLessonStatusMapper
	{
		LessonStatus MapBOToEF(
			BOLessonStatus bo);

		BOLessonStatus MapEFToBO(
			LessonStatus efLessonStatus);

		List<BOLessonStatus> MapEFToBO(
			List<LessonStatus> records);
	}
}

/*<Codenesium>
    <Hash>015f96a787362e461fd237e46bfcb0a5</Hash>
</Codenesium>*/