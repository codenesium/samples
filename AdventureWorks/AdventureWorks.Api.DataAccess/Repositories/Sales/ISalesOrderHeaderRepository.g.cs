using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface ISalesOrderHeaderRepository
        {
                Task<SalesOrderHeader> Create(SalesOrderHeader item);

                Task Update(SalesOrderHeader item);

                Task Delete(int salesOrderID);

                Task<SalesOrderHeader> Get(int salesOrderID);

                Task<List<SalesOrderHeader>> All(int limit = int.MaxValue, int offset = 0);

                Task<SalesOrderHeader> BySalesOrderNumber(string salesOrderNumber);

                Task<List<SalesOrderHeader>> ByCustomerID(int customerID);

                Task<List<SalesOrderHeader>> BySalesPersonID(Nullable<int> salesPersonID);

                Task<List<SalesOrderDetail>> SalesOrderDetails(int salesOrderID, int limit = int.MaxValue, int offset = 0);

                Task<List<SalesOrderHeaderSalesReason>> SalesOrderHeaderSalesReasons(int salesOrderID, int limit = int.MaxValue, int offset = 0);

                Task<CreditCard> GetCreditCard(int creditCardID);

                Task<CurrencyRate> GetCurrencyRate(int currencyRateID);

                Task<Customer> GetCustomer(int customerID);

                Task<SalesPerson> GetSalesPerson(int salesPersonID);

                Task<SalesTerritory> GetSalesTerritory(int territoryID);
        }
}

/*<Codenesium>
    <Hash>674d20133776173fc7170b703094e249</Hash>
</Codenesium>*/