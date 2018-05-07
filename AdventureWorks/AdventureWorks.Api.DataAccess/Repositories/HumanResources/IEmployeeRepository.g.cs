using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IEmployeeRepository
	{
		int Create(EmployeeModel model);

		void Update(int businessEntityID,
		            EmployeeModel model);

		void Delete(int businessEntityID);

		POCOEmployee Get(int businessEntityID);

		List<POCOEmployee> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e7147de288143d5318e647d03bfc0e7f</Hash>
</Codenesium>*/