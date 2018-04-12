using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesOrderHeaderRepository
	{
		int Create(
			int revisionNumber,
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

		void Update(int salesOrderID,
		            int revisionNumber,
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

		Response GetById(int salesOrderID);

		POCOSalesOrderHeader GetByIdDirect(int salesOrderID);

		Response GetWhere(Expression<Func<EFSalesOrderHeader, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOSalesOrderHeader> GetWhereDirect(Expression<Func<EFSalesOrderHeader, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>dc6a9e867f36003a2cd67f6ee850461d</Hash>
</Codenesium>*/