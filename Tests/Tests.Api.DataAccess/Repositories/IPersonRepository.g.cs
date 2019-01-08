using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestsNS.Api.DataAccess
{
	public partial interface IPersonRepository
	{
		Task<Person> Create(Person item);

		Task Update(Person item);

		Task Delete(int personId);

		Task<Person> Get(int personId);

		Task<List<Person>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ColumnSameAsFKTable>> ColumnSameAsFKTablesByPerson(int person, int limit = int.MaxValue, int offset = 0);

		Task<List<ColumnSameAsFKTable>> ColumnSameAsFKTablesByPersonId(int personId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>e04b5acd7bd61e90263b954e5f8ce744</Hash>
</Codenesium>*/