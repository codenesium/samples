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

		POCOShift Get(int shiftID);

		List<POCOShift> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOShift GetName(string name);

		POCOShift GetStartTimeEndTime(TimeSpan startTime,TimeSpan endTime);
	}
}

/*<Codenesium>
    <Hash>4240568e831396039ff3d784b8ab1fcc</Hash>
</Codenesium>*/