using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public interface IEmployeeRepository
	{
		Task<Employee> Create(Employee item);

		Task Update(Employee item);

		Task Delete(int id);

		Task<Employee> Get(int id);

		Task<List<Employee>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>86d5f0e1cb3a0b2106885ae952c11022</Hash>
</Codenesium>*/