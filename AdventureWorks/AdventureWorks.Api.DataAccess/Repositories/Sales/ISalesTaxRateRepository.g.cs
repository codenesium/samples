using System;
using System.Linq.Expressions;
using System.Collections.Generic;
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

		Response GetById(int salesTaxRateID);

		POCOSalesTaxRate GetByIdDirect(int salesTaxRateID);

		Response GetWhere(Expression<Func<EFSalesTaxRate, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOSalesTaxRate> GetWhereDirect(Expression<Func<EFSalesTaxRate, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9c4a23d3bb51afd1a9d213d763a15812</Hash>
</Codenesium>*/