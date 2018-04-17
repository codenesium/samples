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

		ApiResponse GetById(int shiftID);

		POCOShift GetByIdDirect(int shiftID);

		ApiResponse GetWhere(Expression<Func<EFShift, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOShift> GetWhereDirect(Expression<Func<EFShift, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>8448fc2657d676f8b25808210a6a280e</Hash>
</Codenesium>*/