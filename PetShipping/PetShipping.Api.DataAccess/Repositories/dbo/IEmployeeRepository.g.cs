using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IEmployeeRepository
	{
		POCOEmployee Create(ApiEmployeeModel model);

		void Update(int id,
		            ApiEmployeeModel model);

		void Delete(int id);

		POCOEmployee Get(int id);

		List<POCOEmployee> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e61af9b6dbd0079bf8dfaed4637a8d0c</Hash>
</Codenesium>*/