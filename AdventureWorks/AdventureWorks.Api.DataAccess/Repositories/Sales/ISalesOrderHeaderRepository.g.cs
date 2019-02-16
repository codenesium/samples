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

		Task<List<SalesOrderHeader>> All(int limit = int.MaxValue, int offset = 0, string query = "");

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
    <Hash>32a6c8a19e8772a1e7ad74b1a68592e8</Hash>
</Codenesium>*/