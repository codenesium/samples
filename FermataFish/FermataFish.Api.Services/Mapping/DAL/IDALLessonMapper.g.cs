using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.Services
{
	public interface IDALLessonMapper
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
    <Hash>396c0b4ebdd7244e32a3d68ac443fc7c</Hash>
</Codenesium>*/