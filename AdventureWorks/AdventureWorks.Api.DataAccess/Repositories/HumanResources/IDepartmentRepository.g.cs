using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IDepartmentRepository
        {
                Task<Department> Create(Department item);

                Task Update(Department item);

                Task Delete(short departmentID);

                Task<Department> Get(short departmentID);

                Task<List<Department>> All(int limit = int.MaxValue, int offset = 0);

                Task<Department> ByName(string name);

                Task<List<EmployeeDepartmentHistory>> EmployeeDepartmentHistories(short departmentID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>f13974021751323c3b362327142dd339</Hash>
</Codenesium>*/