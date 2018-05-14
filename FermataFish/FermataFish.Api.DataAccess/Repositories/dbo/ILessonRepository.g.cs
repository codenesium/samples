using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ILessonRepository
	{
		POCOLesson Create(LessonModel model);

		void Update(int id,
		            LessonModel model);

		void Delete(int id);

		POCOLesson Get(int id);

		List<POCOLesson> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c3eaa6774214fb9e8e1c8b6770573023</Hash>
</Codenesium>*/