using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IEmployeeRepository
	{
		Task<Employee> Create(Employee item);

		Task Update(Employee item);

		Task Delete(int businessEntityID);

		Task<Employee> Get(int businessEntityID);

		Task<List<Employee>> All(int limit = int.MaxValue, int offset = 0);

		Task<Employee> ByLoginID(string loginID);

		Task<Employee> ByNationalIDNumber(string nationalIDNumber);

		Task<List<EmployeeDepartmentHistory>> EmployeeDepartmentHistoriesByBusinessEntityID(int businessEntityID, int limit = int.MaxValue, int offset = 0);

		Task<List<EmployeePayHistory>> EmployeePayHistoriesByBusinessEntityID(int businessEntityID, int limit = int.MaxValue, int offset = 0);

		Task<List<JobCandidate>> JobCandidatesByBusinessEntityID(int businessEntityID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>038003807fdd65bec9b1b109ce62e261</Hash>
</Codenesium>*/