using System;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesTaxRateRepository
	{
		int Create(int stateProvinceID,
		           int taxType,
		           decimal taxRate,
		           string name,
		           Guid rowguid,
		           DateTime modifiedDate);

		void Update(int salesTaxRateID, int stateProvinceID,
		            int taxType,
		            decimal taxRate,
		            string name,
		            Guid rowguid,
		            DateTime modifiedDate);

		void Delete(int salesTaxRateID);

		void GetById(int salesTaxRateID, Response response);

		void GetWhere(Expression<Func<EFSalesTaxRate, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1a256f7839fb3112319d9f2495f9d577</Hash>
</Codenesium>*/