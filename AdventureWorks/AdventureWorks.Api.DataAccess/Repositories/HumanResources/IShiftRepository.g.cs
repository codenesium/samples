using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IShiftRepository
        {
                Task<Shift> Create(Shift item);

                Task Update(Shift item);

                Task Delete(int shiftID);

                Task<Shift> Get(int shiftID);

                Task<List<Shift>> All(int limit = int.MaxValue, int offset = 0);

                Task<Shift> ByName(string name);
                Task<Shift> ByStartTimeEndTime(TimeSpan startTime, TimeSpan endTime);

                Task<List<EmployeeDepartmentHistory>> EmployeeDepartmentHistories(int shiftID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>449a83118e042e57bd11ca8b094fbe1b</Hash>
</Codenesium>*/