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

		Task<List<ColumnSameAsFKTable>> ColumnSameAsFKTables(int person, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>6e3b15b242dd3a7208a47e5bb0c623da</Hash>
</Codenesium>*/