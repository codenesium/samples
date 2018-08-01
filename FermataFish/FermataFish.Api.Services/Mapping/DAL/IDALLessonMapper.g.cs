using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>ca3a0ffac51076ae63ff0d1190e880da</Hash>
</Codenesium>*/