using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IEmployeeDepartmentHistoryRepository
        {
                Task<EmployeeDepartmentHistory> Create(EmployeeDepartmentHistory item);

                Task Update(EmployeeDepartmentHistory item);

                Task Delete(int businessEntityID);

                Task<EmployeeDepartmentHistory> Get(int businessEntityID);

                Task<List<EmployeeDepartmentHistory>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<EmployeeDepartmentHistory>> ByDepartmentID(short departmentID);
                Task<List<EmployeeDepartmentHistory>> ByShiftID(int shiftID);
        }
}

/*<Codenesium>
    <Hash>5f5c5fe04d1ad0073d8e89f0f8788079</Hash>
</Codenesium>*/