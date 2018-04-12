using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesTaxRateRepository
	{
		int Create(
			int stateProvinceID,
			int taxType,
			decimal taxRate,
			string name,
			Guid rowguid,
			DateTime modifiedDate);

		void Update(int salesTaxRateID,
		            int stateProvinceID,
		            int taxType,
		            decimal taxRate,
		            string name,
		            Guid rowguid,
		            DateTime modifiedDate);

		void Delete(int salesTaxRateID);

		Response GetById(int salesTaxRateID);

		POCOSalesTaxRate GetByIdDirect(int salesTaxRateID);

		Response GetWhere(Expression<Func<EFSalesTaxRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOSalesTaxRate> GetWhereDirect(Expression<Func<EFSalesTaxRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>788796bc7a09dd103935eb4050528bcb</Hash>
</Codenesium>*/