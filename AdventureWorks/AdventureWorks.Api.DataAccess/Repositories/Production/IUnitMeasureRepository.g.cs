using System;
using System.Linq.Expressions;
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

		void GetById(string unitMeasureCode, Response response);

		void GetWhere(Expression<Func<EFUnitMeasure, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>56ed912e734423133bd9b71cff082cd5</Hash>
</Codenesium>*/