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
    <Hash>915943063d7376f78e65360e1855336c</Hash>
</Codenesium>*/