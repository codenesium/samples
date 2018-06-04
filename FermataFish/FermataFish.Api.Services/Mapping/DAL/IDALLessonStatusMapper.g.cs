using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
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
    <Hash>abd98e040be8c4a0a4502aab1c3fb50f</Hash>
</Codenesium>*/