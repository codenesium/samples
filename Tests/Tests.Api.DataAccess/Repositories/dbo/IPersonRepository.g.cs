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
	}
}

/*<Codenesium>
    <Hash>4ae6c6a7c075f8f4591032434e95751a</Hash>
</Codenesium>*/