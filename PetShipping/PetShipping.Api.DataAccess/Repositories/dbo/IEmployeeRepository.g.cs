using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IEmployeeRepository
	{
		POCOEmployee Create(EmployeeModel model);

		void Update(int id,
		            EmployeeModel model);

		void Delete(int id);

		POCOEmployee Get(int id);

		List<POCOEmployee> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e705f73beaabcfbaea21a60acba1adf6</Hash>
</Codenesium>*/