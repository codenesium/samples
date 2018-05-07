using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IEmployeeRepository
	{
		int Create(EmployeeModel model);

		void Update(int id,
		            EmployeeModel model);

		void Delete(int id);

		POCOEmployee Get(int id);

		List<POCOEmployee> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>4ac8ecaa6977691257c893f67633395f</Hash>
</Codenesium>*/