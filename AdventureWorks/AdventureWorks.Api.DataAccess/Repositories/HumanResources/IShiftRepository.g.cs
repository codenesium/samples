using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IShiftRepository
	{
		Task<POCOShift> Create(ApiShiftModel model);

		Task Update(int shiftID,
		            ApiShiftModel model);

		Task Delete(int shiftID);

		Task<POCOShift> Get(int shiftID);

		Task<List<POCOShift>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOShift> GetName(string name);
		Task<POCOShift> GetStartTimeEndTime(TimeSpan startTime,TimeSpan endTime);
	}
}

/*<Codenesium>
    <Hash>f88f939a1002a0ab590e58114b9194e1</Hash>
</Codenesium>*/