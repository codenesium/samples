using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
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
    <Hash>345d43841d61e60dc372f4872f798264</Hash>
</Codenesium>*/