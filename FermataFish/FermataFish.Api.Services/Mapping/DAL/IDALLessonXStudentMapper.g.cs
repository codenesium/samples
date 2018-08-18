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
    <Hash>de25c819df0dd8bd2ee502a86edd33c6</Hash>
</Codenesium>*/