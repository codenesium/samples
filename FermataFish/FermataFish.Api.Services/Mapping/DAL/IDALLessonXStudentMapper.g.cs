using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public interface IDALLessonXStudentMapper
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
    <Hash>91021adcb4a3d6cb4e9952748fd607f0</Hash>
</Codenesium>*/