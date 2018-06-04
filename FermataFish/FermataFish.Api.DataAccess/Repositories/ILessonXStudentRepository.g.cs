using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
	public interface ILessonXStudentRepository
	{
		Task<LessonXStudent> Create(LessonXStudent item);

		Task Update(LessonXStudent item);

		Task Delete(int id);

		Task<LessonXStudent> Get(int id);

		Task<List<LessonXStudent>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f5d7c0c956f005e7ed17ee12e3857a51</Hash>
</Codenesium>*/