using System;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductVendorRepository
	{
		int Create(int businessEntityID,
		           int averageLeadTime,
		           decimal standardPrice,
		           Nullable<decimal> lastReceiptCost,
		           Nullable<DateTime> lastReceiptDate,
		           int minOrderQty,
		           int maxOrderQty,
		           Nullable<int> onOrderQty,
		           string unitMeasureCode,
		           DateTime modifiedDate);

		void Update(int productID, int businessEntityID,
		            int averageLeadTime,
		            decimal standardPrice,
		            Nullable<decimal> lastReceiptCost,
		            Nullable<DateTime> lastReceiptDate,
		            int minOrderQty,
		            int maxOrderQty,
		            Nullable<int> onOrderQty,
		            string unitMeasureCode,
		            DateTime modifiedDate);

		void Delete(int productID);

		void GetById(int productID, Response response);

		void GetWhere(Expression<Func<EFProductVendor, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f7556321fb388f5d1dfde0343d5849dc</Hash>
</Codenesium>*/