using System;
using System.Linq.Expressions;
using System.Collections.Generic;
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

		Response GetById(int productID);

		POCOProductVendor GetByIdDirect(int productID);

		Response GetWhere(Expression<Func<EFProductVendor, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOProductVendor> GetWhereDirect(Expression<Func<EFProductVendor, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>5f8a0b2f917a49971ce1fe55434efc00</Hash>
</Codenesium>*/