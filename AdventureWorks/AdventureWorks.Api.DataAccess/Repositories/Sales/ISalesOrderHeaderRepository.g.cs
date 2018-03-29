using System;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesOrderHeaderRepository
	{
		int Create(int revisionNumber,
		           DateTime orderDate,
		           DateTime dueDate,
		           Nullable<DateTime> shipDate,
		           int status,
		           bool onlineOrderFlag,
		           string salesOrderNumber,
		           string purchaseOrderNumber,
		           string accountNumber,
		           int customerID,
		           Nullable<int> salesPersonID,
		           Nullable<int> territoryID,
		           int billToAddressID,
		           int shipToAddressID,
		           int shipMethodID,
		           Nullable<int> creditCardID,
		           string creditCardApprovalCode,
		           Nullable<int> currencyRateID,
		           decimal subTotal,
		           decimal taxAmt,
		           decimal freight,
		           decimal totalDue,
		           string comment,
		           Guid rowguid,
		           DateTime modifiedDate);

		void Update(int salesOrderID, int revisionNumber,
		            DateTime orderDate,
		            DateTime dueDate,
		            Nullable<DateTime> shipDate,
		            int status,
		            bool onlineOrderFlag,
		            string salesOrderNumber,
		            string purchaseOrderNumber,
		            string accountNumber,
		            int customerID,
		            Nullable<int> salesPersonID,
		            Nullable<int> territoryID,
		            int billToAddressID,
		            int shipToAddressID,
		            int shipMethodID,
		            Nullable<int> creditCardID,
		            string creditCardApprovalCode,
		            Nullable<int> currencyRateID,
		            decimal subTotal,
		            decimal taxAmt,
		            decimal freight,
		            decimal totalDue,
		            string comment,
		            Guid rowguid,
		            DateTime modifiedDate);

		void Delete(int salesOrderID);

		void GetById(int salesOrderID, Response response);

		void GetWhere(Expression<Func<EFSalesOrderHeader, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d19f0a2dba3cec503cd7a985886df6e9</Hash>
</Codenesium>*/