using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface ISalesOrderHeaderRepository
	{
		Task<SalesOrderHeader> Create(SalesOrderHeader item);

		Task Update(SalesOrderHeader item);

		Task Delete(int salesOrderID);

		Task<SalesOrderHeader> Get(int salesOrderID);

		Task<List<SalesOrderHeader>> All(int limit = int.MaxValue, int offset = 0);

		Task<SalesOrderHeader> ByRowguid(Guid rowguid);

		Task<SalesOrderHeader> BySalesOrderNumber(string salesOrderNumber);

		Task<List<SalesOrderHeader>> ByCustomerID(int customerID, int limit = int.MaxValue, int offset = 0);

		Task<List<SalesOrderHeader>> BySalesPersonID(int? salesPersonID, int limit = int.MaxValue, int offset = 0);

		Task<CreditCard> CreditCardByCreditCardID(int? creditCardID);

		Task<CurrencyRate> CurrencyRateByCurrencyRateID(int? currencyRateID);

		Task<Customer> CustomerByCustomerID(int customerID);

		Task<SalesPerson> SalesPersonBySalesPersonID(int? salesPersonID);

		Task<SalesTerritory> SalesTerritoryByTerritoryID(int? territoryID);
	}
}

/*<Codenesium>
    <Hash>b3a81513c6a2bd91ce9212111e129c15</Hash>
</Codenesium>*/