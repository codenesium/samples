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
	}
}

/*<Codenesium>
    <Hash>3a4f293e6b4e4fbc97c0857d851e9158</Hash>
</Codenesium>*/