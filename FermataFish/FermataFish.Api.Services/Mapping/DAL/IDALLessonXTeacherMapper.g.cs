using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public partial interface IDALLessonXTeacherMapper
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
    <Hash>2897942f22d518bd044b9205752036d8</Hash>
</Codenesium>*/