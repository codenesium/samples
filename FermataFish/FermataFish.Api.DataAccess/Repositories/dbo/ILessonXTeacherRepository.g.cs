using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ILessonXTeacherRepository
	{
		Task<POCOLessonXTeacher> Create(ApiLessonXTeacherModel model);

		Task Update(int id,
		            ApiLessonXTeacherModel model);

		Task Delete(int id);

		Task<POCOLessonXTeacher> Get(int id);

		Task<List<POCOLessonXTeacher>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b020013dbdeb95d17c418f924cc25747</Hash>
</Codenesium>*/