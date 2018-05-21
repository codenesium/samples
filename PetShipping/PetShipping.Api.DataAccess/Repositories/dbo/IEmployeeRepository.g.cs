using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IEmployeeRepository
	{
		Task<POCOEmployee> Create(ApiEmployeeModel model);

		Task Update(int id,
		            ApiEmployeeModel model);

		Task Delete(int id);

		Task<POCOEmployee> Get(int id);

		Task<List<POCOEmployee>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>90122499577f4f43eece29c936ed02bb</Hash>
</Codenesium>*/