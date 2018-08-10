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

		Task<List<EmployeeDepartmentHistory>> EmployeeDepartmentHistories(int businessEntityID, int limit = int.MaxValue, int offset = 0);

		Task<List<EmployeePayHistory>> EmployeePayHistories(int businessEntityID, int limit = int.MaxValue, int offset = 0);

		Task<List<JobCandidate>> JobCandidates(int businessEntityID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>d3f965960bc2e7039234b4815575f5ae</Hash>
</Codenesium>*/