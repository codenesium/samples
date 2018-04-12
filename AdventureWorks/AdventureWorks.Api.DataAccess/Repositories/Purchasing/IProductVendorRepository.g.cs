using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductVendorRepository
	{
		int Create(
			int businessEntityID,
			int averageLeadTime,
			decimal standardPrice,
			Nullable<decimal> lastReceiptCost,
			Nullable<DateTime> lastReceiptDate,
			int minOrderQty,
			int maxOrderQty,
			Nullable<int> onOrderQty,
			string unitMeasureCode,
			DateTime modifiedDate);

		void Update(int productID,
		            int businessEntityID,
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

		Response GetWhere(Expression<Func<EFProductVendor, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOProductVendor> GetWhereDirect(Expression<Func<EFProductVendor, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>76819ae16e4a7ba26a1258543aa06548</Hash>
</Codenesium>*/