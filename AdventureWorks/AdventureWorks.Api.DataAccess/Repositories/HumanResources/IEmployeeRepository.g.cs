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

		Task<List<Employee>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<Employee> ByLoginID(string loginID);

		Task<Employee> ByNationalIDNumber(string nationalIDNumber);

		Task<Employee> ByRowguid(Guid rowguid);

		Task<List<JobCandidate>> JobCandidatesByBusinessEntityID(int businessEntityID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>666007791256a120f334d7b04a61c8f8</Hash>
</Codenesium>*/