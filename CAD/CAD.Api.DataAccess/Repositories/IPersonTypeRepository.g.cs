using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CADNS.Api.DataAccess
{
	public partial interface IPersonTypeRepository
	{
		Task<PersonType> Create(PersonType item);

		Task Update(PersonType item);

		Task Delete(int id);

		Task<PersonType> Get(int id);

		Task<List<PersonType>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<CallPerson>> CallPersonsByPersonTypeId(int personTypeId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>d42f76fcea411131b0dbb67fe982f42b</Hash>
</Codenesium>*/