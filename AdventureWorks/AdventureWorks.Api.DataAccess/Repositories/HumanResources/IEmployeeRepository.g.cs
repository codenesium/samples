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

                Task<List<Employee>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<Employee> GetLoginID(string loginID);
                Task<Employee> GetNationalIDNumber(string nationalIDNumber);
                Task<List<Employee>> GetOrganizationLevelOrganizationNode(Nullable<short> organizationLevel, Nullable<Guid> organizationNode);
                Task<List<Employee>> GetOrganizationNode(Nullable<Guid> organizationNode);

                Task<List<EmployeeDepartmentHistory>> EmployeeDepartmentHistories(int businessEntityID, int limit = int.MaxValue, int offset = 0);
                Task<List<EmployeePayHistory>> EmployeePayHistories(int businessEntityID, int limit = int.MaxValue, int offset = 0);
                Task<List<JobCandidate>> JobCandidates(int businessEntityID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>a553117eaf7a7cf07632b3659d6aec93</Hash>
</Codenesium>*/