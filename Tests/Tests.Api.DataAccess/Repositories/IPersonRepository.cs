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

		Task<List<Person>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ColumnSameAsFKTable>> ColumnSameAsFKTablesByPerson(int person, int limit = int.MaxValue, int offset = 0);

		Task<List<ColumnSameAsFKTable>> ColumnSameAsFKTablesByPersonId(int personId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>1b8f9cf9b09bbd83c16adf288ff9d41d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/