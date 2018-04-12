using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesOrderDetailRepository
	{
		int Create(
			int salesOrderDetailID,
			string carrierTrackingNumber,
			short orderQty,
			int productID,
			int specialOfferID,
			decimal unitPrice,
			decimal unitPriceDiscount,
			decimal lineTotal,
			Guid rowguid,
			DateTime modifiedDate);

		void Update(int salesOrderID,
		            int salesOrderDetailID,
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

		Response GetById(int salesOrderID);

		POCOSalesOrderDetail GetByIdDirect(int salesOrderID);

		Response GetWhere(Expression<Func<EFSalesOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOSalesOrderDetail> GetWhereDirect(Expression<Func<EFSalesOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a24717f4a18b93bcd1658969cd8954de</Hash>
</Codenesium>*/