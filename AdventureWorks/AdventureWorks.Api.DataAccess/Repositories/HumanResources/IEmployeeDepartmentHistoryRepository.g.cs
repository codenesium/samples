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

                Task<List<EmployeeDepartmentHistory>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<EmployeeDepartmentHistory>> GetDepartmentID(short departmentID);
                Task<List<EmployeeDepartmentHistory>> GetShiftID(int shiftID);
        }
}

/*<Codenesium>
    <Hash>3f45fa83dc2df06d896ba9e7f59b21a0</Hash>
</Codenesium>*/