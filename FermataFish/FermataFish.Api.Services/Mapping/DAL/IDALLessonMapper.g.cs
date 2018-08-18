using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public partial interface IDALLessonMapper
	{
		Lesson MapBOToEF(
			BOLesson bo);

		BOLesson MapEFToBO(
			Lesson efLesson);

		List<BOLesson> MapEFToBO(
			List<Lesson> records);
	}
}

/*<Codenesium>
    <Hash>11b2bb4c6858590a226e60552a2bda97</Hash>
</Codenesium>*/