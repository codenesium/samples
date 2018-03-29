using System;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesOrderDetailRepository
	{
		int Create(int salesOrderDetailID,
		           string carrierTrackingNumber,
		           short orderQty,
		           int productID,
		           int specialOfferID,
		           decimal unitPrice,
		           decimal unitPriceDiscount,
		           decimal lineTotal,
		           Guid rowguid,
		           DateTime modifiedDate);

		void Update(int salesOrderID, int salesOrderDetailID,
		            string carrierTrackingNumber,
		            short orderQty,
		            int productID,
		            int specialOfferID,
		            decimal unitPrice,
		            decimal unitPriceDiscount,
		            decimal lineTotal,
		            Guid rowguid,
		            DateTime modifiedDate);

		void Delete(int salesOrderID);

		void GetById(int salesOrderID, Response response);

		void GetWhere(Expression<Func<EFSalesOrderDetail, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9d4ddf6f505f05542cd91d2794e15073</Hash>
</Codenesium>*/