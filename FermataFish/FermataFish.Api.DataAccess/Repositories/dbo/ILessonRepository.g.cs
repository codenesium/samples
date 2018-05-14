using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ILessonRepository
	{
		POCOLesson Create(ApiLessonModel model);

		void Update(int id,
		            ApiLessonModel model);

		void Delete(int id);

		POCOLesson Get(int id);

		List<POCOLesson> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d98e615362eba9e4c25e7c3b76cd1c98</Hash>
</Codenesium>*/