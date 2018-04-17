using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOStateProvince
	{
		Task<CreateResponse<int>> Create(
			StateProvinceModel model);

		Task<ActionResponse> Update(int stateProvinceID,
		                            StateProvinceModel model);

		Task<ActionResponse> Delete(int stateProvinceID);

		ApiResponse GetById(int stateProvinceID);

		POCOStateProvince GetByIdDirect(int stateProvinceID);

		ApiResponse GetWhere(Expression<Func<EFStateProvince, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOStateProvince> GetWhereDirect(Expression<Func<EFStateProvince, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>464318e2ceb6d41effafea4b1398861e</Hash>
</Codenesium>*/