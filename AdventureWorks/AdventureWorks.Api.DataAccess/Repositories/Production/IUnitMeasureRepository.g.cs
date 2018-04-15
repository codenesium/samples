using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IUnitMeasureRepository
	{
		string Create(UnitMeasureModel model);

		void Update(string unitMeasureCode,
		            UnitMeasureModel model);

		void Delete(string unitMeasureCode);

		ApiResponse GetById(string unitMeasureCode);

		POCOUnitMeasure GetByIdDirect(string unitMeasureCode);

		ApiResponse GetWhere(Expression<Func<EFUnitMeasure, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOUnitMeasure> GetWhereDirect(Expression<Func<EFUnitMeasure, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c3e410cca02c69504ff6dce8865c54ad</Hash>
</Codenesium>*/