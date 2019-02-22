using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CADNS.Api.DataAccess
{
	public partial interface IPersonRepository
	{
		Task<Person> Create(Person item);

		Task Update(Person item);

		Task Delete(int id);

		Task<Person> Get(int id);

		Task<List<Person>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<CallPerson>> CallPersonsByPersonId(int personId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>6d683a09b7e99227d20f6bee6efb52e0</Hash>
</Codenesium>*/