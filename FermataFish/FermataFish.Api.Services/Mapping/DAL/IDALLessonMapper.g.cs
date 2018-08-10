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
    <Hash>3d48e28778e42fdd419f3e5381da7431</Hash>
</Codenesium>*/