using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOUnitMeasure
	{
		Task<CreateResponse<string>> Create(
			UnitMeasureModel model);

		Task<ActionResponse> Update(string unitMeasureCode,
		                            UnitMeasureModel model);

		Task<ActionResponse> Delete(string unitMeasureCode);

		ApiResponse GetById(string unitMeasureCode);

		POCOUnitMeasure GetByIdDirect(string unitMeasureCode);

		ApiResponse GetWhere(Expression<Func<EFUnitMeasure, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOUnitMeasure> GetWhereDirect(Expression<Func<EFUnitMeasure, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>7f1df9e7115255a45096d391d600351b</Hash>
</Codenesium>*/