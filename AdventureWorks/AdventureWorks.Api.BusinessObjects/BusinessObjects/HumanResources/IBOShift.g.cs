using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOShift
	{
		Task<CreateResponse<POCOShift>> Create(
			ApiShiftModel model);

		Task<ActionResponse> Update(int shiftID,
		                            ApiShiftModel model);

		Task<ActionResponse> Delete(int shiftID);

		Task<POCOShift> Get(int shiftID);

		Task<List<POCOShift>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOShift> GetName(string name);
		Task<POCOShift> GetStartTimeEndTime(TimeSpan startTime,TimeSpan endTime);
	}
}

/*<Codenesium>
    <Hash>6b43bcf4d8058f78d27803b29af89db4</Hash>
</Codenesium>*/