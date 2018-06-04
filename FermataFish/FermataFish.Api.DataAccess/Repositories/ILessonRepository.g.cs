using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
	public interface ILessonRepository
	{
		Task<Lesson> Create(Lesson item);

		Task Update(Lesson item);

		Task Delete(int id);

		Task<Lesson> Get(int id);

		Task<List<Lesson>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>6de0b5c2ede37ee6f2f7b88d0ee5658c</Hash>
</Codenesium>*/