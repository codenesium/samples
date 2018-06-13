using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IDepartmentRepository
        {
                Task<Department> Create(Department item);

                Task Update(Department item);

                Task Delete(short departmentID);

                Task<Department> Get(short departmentID);

                Task<List<Department>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<Department> GetName(string name);

                Task<List<EmployeeDepartmentHistory>> EmployeeDepartmentHistories(short departmentID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>f79c2339edb1efc1dbb0ef8ba307325a</Hash>
</Codenesium>*/