using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ILessonStatusRepository
	{
		POCOLessonStatus Create(LessonStatusModel model);

		void Update(int id,
		            LessonStatusModel model);

		void Delete(int id);

		POCOLessonStatus Get(int id);

		List<POCOLessonStatus> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>3952a1ce113bd6b30babc24ce516b2b8</Hash>
</Codenesium>*/