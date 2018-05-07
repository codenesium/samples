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
		Task<CreateResponse<int>> Create(
			ShiftModel model);

		Task<ActionResponse> Update(int shiftID,
		                            ShiftModel model);

		Task<ActionResponse> Delete(int shiftID);

		POCOShift Get(int shiftID);

		List<POCOShift> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c1fc618d59f697757e91a1bfca52d90d</Hash>
</Codenesium>*/