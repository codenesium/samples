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

		Task<List<Shift>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<Shift> ByName(string name);

		Task<Shift> ByStartTimeEndTime(TimeSpan startTime, TimeSpan endTime);
	}
}

/*<Codenesium>
    <Hash>31c55798169c1483374716883d920146</Hash>
</Codenesium>*/