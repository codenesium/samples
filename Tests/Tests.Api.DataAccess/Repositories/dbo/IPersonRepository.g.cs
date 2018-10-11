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
    <Hash>3607079d2f3fe55d7b044a89826cb6fa</Hash>
</Codenesium>*/