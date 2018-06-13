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

                Task<List<Shift>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<Shift> GetName(string name);
                Task<Shift> GetStartTimeEndTime(TimeSpan startTime, TimeSpan endTime);

                Task<List<EmployeeDepartmentHistory>> EmployeeDepartmentHistories(int shiftID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>fc33246dce77e7e3a809feff07281b06</Hash>
</Codenesium>*/