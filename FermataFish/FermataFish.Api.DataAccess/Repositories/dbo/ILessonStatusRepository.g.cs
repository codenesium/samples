using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ILessonStatusRepository
	{
		POCOLessonStatus Create(ApiLessonStatusModel model);

		void Update(int id,
		            ApiLessonStatusModel model);

		void Delete(int id);

		POCOLessonStatus Get(int id);

		List<POCOLessonStatus> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>438ab986957f0ce6cd77e662633ef00f</Hash>
</Codenesium>*/