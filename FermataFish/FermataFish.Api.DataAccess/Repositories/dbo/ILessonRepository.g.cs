using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ILessonRepository
	{
		int Create(LessonModel model);

		void Update(int id,
		            LessonModel model);

		void Delete(int id);

		POCOLesson Get(int id);

		List<POCOLesson> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>dfb5dcd0d8ad45719b797a0f71ac78fa</Hash>
</Codenesium>*/