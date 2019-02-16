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

		Task<List<ColumnSameAsFKTable>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<Person> PersonByPerson(int person);

		Task<Person> PersonByPersonId(int personId);
	}
}

/*<Codenesium>
    <Hash>c85d2bdd472e269c93445ea6ca2ee438</Hash>
</Codenesium>*/