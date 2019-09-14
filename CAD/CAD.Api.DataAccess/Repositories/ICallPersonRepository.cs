using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CADNS.Api.DataAccess
{
	public partial interface ICallPersonRepository
	{
		Task<CallPerson> Create(CallPerson item);

		Task Update(CallPerson item);

		Task Delete(int id);

		Task<CallPerson> Get(int id);

		Task<List<CallPerson>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<Person> PersonByPersonId(int personId);

		Task<PersonType> PersonTypeByPersonTypeId(int personTypeId);
	}
}

/*<Codenesium>
    <Hash>46606c9a3accd9f998773506585de227</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/