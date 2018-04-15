using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IStateProvinceRepository
	{
		int Create(StateProvinceModel model);

		void Update(int stateProvinceID,
		            StateProvinceModel model);

		void Delete(int stateProvinceID);

		ApiResponse GetById(int stateProvinceID);

		POCOStateProvince GetByIdDirect(int stateProvinceID);

		ApiResponse GetWhere(Expression<Func<EFStateProvince, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOStateProvince> GetWhereDirect(Expression<Func<EFStateProvince, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>7ca283e71f854059a6be5d2b4764b92c</Hash>
</Codenesium>*/