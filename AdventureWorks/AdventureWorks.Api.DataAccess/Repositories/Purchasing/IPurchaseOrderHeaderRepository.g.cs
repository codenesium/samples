using System;
using System.Linq.Expressions;
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

		void GetById(int purchaseOrderID, Response response);

		void GetWhere(Expression<Func<EFPurchaseOrderHeader, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>83bf4b12d178c9d9d69e469191877337</Hash>
</Codenesium>*/