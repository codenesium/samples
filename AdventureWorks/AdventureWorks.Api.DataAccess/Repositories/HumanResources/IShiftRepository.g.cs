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

		Task<List<EmployeeDepartmentHistory>> EmployeeDepartmentHistoriesByShiftID(int shiftID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>1a9f6fb8424ece3480928dd7a4471919</Hash>
</Codenesium>*/