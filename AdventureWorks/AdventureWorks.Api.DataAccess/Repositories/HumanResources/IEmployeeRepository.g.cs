using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IEmployeeRepository
	{
		Task<Employee> Create(Employee item);

		Task Update(Employee item);

		Task Delete(int businessEntityID);

		Task<Employee> Get(int businessEntityID);

		Task<List<Employee>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<Employee> GetLoginID(string loginID);
		Task<Employee> GetNationalIDNumber(string nationalIDNumber);
		Task<List<Employee>> GetOrganizationLevelOrganizationNode(Nullable<short> organizationLevel,Nullable<Guid> organizationNode);
		Task<List<Employee>> GetOrganizationNode(Nullable<Guid> organizationNode);
	}
}

/*<Codenesium>
    <Hash>cafbd4918fd81be17b82f9d243efd9f6</Hash>
</Codenesium>*/