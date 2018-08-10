using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public partial interface IDALLessonXStudentMapper
	{
		LessonXStudent MapBOToEF(
			BOLessonXStudent bo);

		BOLessonXStudent MapEFToBO(
			LessonXStudent efLessonXStudent);

		List<BOLessonXStudent> MapEFToBO(
			List<LessonXStudent> records);
	}
}

/*<Codenesium>
    <Hash>828b163d550799df226df5f69e51d569</Hash>
</Codenesium>*/