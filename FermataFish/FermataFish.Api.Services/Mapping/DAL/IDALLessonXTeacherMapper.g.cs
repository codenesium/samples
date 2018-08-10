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
    <Hash>a6025ba10123c1b6ee0ab95df8376822</Hash>
</Codenesium>*/