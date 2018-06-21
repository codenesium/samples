using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    <Hash>461e4c96f04713c9de0ad5f5027e3dbb</Hash>
</Codenesium>*/