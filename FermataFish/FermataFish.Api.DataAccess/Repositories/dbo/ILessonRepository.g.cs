using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ILessonRepository
	{
		Task<DTOLesson> Create(DTOLesson dto);

		Task Update(int id,
		            DTOLesson dto);

		Task Delete(int id);

		Task<DTOLesson> Get(int id);

		Task<List<DTOLesson>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>6872ed65dc395a7016b392115909e4d7</Hash>
</Codenesium>*/