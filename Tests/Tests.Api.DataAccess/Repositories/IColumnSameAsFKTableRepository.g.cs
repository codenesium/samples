using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestsNS.Api.DataAccess
{
	public partial interface IColumnSameAsFKTableRepository
	{
		Task<ColumnSameAsFKTable> Create(ColumnSameAsFKTable item);

		Task Update(ColumnSameAsFKTable item);

		Task Delete(int id);

		Task<ColumnSameAsFKTable> Get(int id);

		Task<List<ColumnSameAsFKTable>> All(int limit = int.MaxValue, int offset = 0);

		Task<Person> PersonByPerson(int person);

		Task<Person> PersonByPersonId(int personId);
	}
}

/*<Codenesium>
    <Hash>bd26e7307c85c3bedcaa129483e35bff</Hash>
</Codenesium>*/