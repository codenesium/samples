using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IShiftRepository
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
    <Hash>6f8d9e298a5301065cd150f1c8a00df5</Hash>
</Codenesium>*/