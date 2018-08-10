using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public partial interface IDALLessonStatusMapper
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
    <Hash>87e4b7d3dd22fe42ee5b55435828e718</Hash>
</Codenesium>*/