using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IUnitMeasureRepository
	{
		string Create(
			string name,
			DateTime modifiedDate);

		void Update(string unitMeasureCode,
		            string name,
		            DateTime modifiedDate);

		void Delete(string unitMeasureCode);

		Response GetById(string unitMeasureCode);

		POCOUnitMeasure GetByIdDirect(string unitMeasureCode);

		Response GetWhere(Expression<Func<EFUnitMeasure, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOUnitMeasure> GetWhereDirect(Expression<Func<EFUnitMeasure, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>52d1e90a370b8a7a06479c854dc11820</Hash>
</Codenesium>*/