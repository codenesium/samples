using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ILessonStatusRepository
	{
		Task<DTOLessonStatus> Create(DTOLessonStatus dto);

		Task Update(int id,
		            DTOLessonStatus dto);

		Task Delete(int id);

		Task<DTOLessonStatus> Get(int id);

		Task<List<DTOLessonStatus>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>bc2db13a0ad9e83e2f38bc50c1e7ffff</Hash>
</Codenesium>*/