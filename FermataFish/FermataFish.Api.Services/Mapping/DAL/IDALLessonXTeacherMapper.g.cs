using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public interface IDALLessonXTeacherMapper
	{
		LessonXTeacher MapBOToEF(
			BOLessonXTeacher bo);

		BOLessonXTeacher MapEFToBO(
			LessonXTeacher efLessonXTeacher);

		List<BOLessonXTeacher> MapEFToBO(
			List<LessonXTeacher> records);
	}
}

/*<Codenesium>
    <Hash>a67f30b2b3ed6ac2f48e7a5b9bc84d9f</Hash>
</Codenesium>*/