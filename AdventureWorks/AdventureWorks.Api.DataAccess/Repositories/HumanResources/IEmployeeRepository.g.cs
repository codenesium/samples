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

		Task<Employee> ByRowguid(Guid rowguid);

		Task<List<JobCandidate>> JobCandidatesByBusinessEntityID(int businessEntityID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>f8f841f2d415da6e84718c0211ba5f08</Hash>
</Codenesium>*/