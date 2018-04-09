using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPurchaseOrderHeaderRepository
	{
		int Create(int revisionNumber,
		           int status,
		           int employeeID,
		           int vendorID,
		           int shipMethodID,
		           DateTime orderDate,
		           Nullable<DateTime> shipDate,
		           decimal subTotal,
		           decimal taxAmt,
		           decimal freight,
		           decimal totalDue,
		           DateTime modifiedDate);

		void Update(int purchaseOrderID, int revisionNumber,
		            int status,
		            int employeeID,
		            int vendorID,
		            int shipMethodID,
		            DateTime orderDate,
		            Nullable<DateTime> shipDate,
		            decimal subTotal,
		            decimal taxAmt,
		            decimal freight,
		            decimal totalDue,
		            DateTime modifiedDate);

		void Delete(int purchaseOrderID);

		Response GetById(int purchaseOrderID);

		POCOPurchaseOrderHeader GetByIdDirect(int purchaseOrderID);

		Response GetWhere(Expression<Func<EFPurchaseOrderHeader, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOPurchaseOrderHeader> GetWhereDirect(Expression<Func<EFPurchaseOrderHeader, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1f585e4ec5928b159e4f2b26e4305c3e</Hash>
</Codenesium>*/