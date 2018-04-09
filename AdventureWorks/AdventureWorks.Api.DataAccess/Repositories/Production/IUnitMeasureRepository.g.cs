using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IUnitMeasureRepository
	{
		string Create(string name,
		              DateTime modifiedDate);

		void Update(string unitMeasureCode, string name,
		            DateTime modifiedDate);

		void Delete(string unitMeasureCode);

		Response GetById(string unitMeasureCode);

		POCOUnitMeasure GetByIdDirect(string unitMeasureCode);

		Response GetWhere(Expression<Func<EFUnitMeasure, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOUnitMeasure> GetWhereDirect(Expression<Func<EFUnitMeasure, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1abd2f2368380d54e7fb5aade54759e7</Hash>
</Codenesium>*/