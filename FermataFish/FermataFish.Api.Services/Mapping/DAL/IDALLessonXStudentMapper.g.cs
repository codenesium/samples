using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
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
    <Hash>cb8877195938226534931f171e12314d</Hash>
</Codenesium>*/