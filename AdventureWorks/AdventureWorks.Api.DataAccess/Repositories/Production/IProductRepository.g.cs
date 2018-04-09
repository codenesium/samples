using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductRepository
	{
		int Create(string name,
		           string productNumber,
		           bool makeFlag,
		           bool finishedGoodsFlag,
		           string color,
		           short safetyStockLevel,
		           short reorderPoint,
		           decimal standardCost,
		           decimal listPrice,
		           string size,
		           string sizeUnitMeasureCode,
		           string weightUnitMeasureCode,
		           Nullable<decimal> weight,
		           int daysToManufacture,
		           string productLine,
		           string @class,
		           string style,
		           Nullable<int> productSubcategoryID,
		           Nullable<int> productModelID,
		           DateTime sellStartDate,
		           Nullable<DateTime> sellEndDate,
		           Nullable<DateTime> discontinuedDate,
		           Guid rowguid,
		           DateTime modifiedDate);

		void Update(int productID, string name,
		            string productNumber,
		            bool makeFlag,
		            bool finishedGoodsFlag,
		            string color,
		            short safetyStockLevel,
		            short reorderPoint,
		            decimal standardCost,
		            decimal listPrice,
		            string size,
		            string sizeUnitMeasureCode,
		            string weightUnitMeasureCode,
		            Nullable<decimal> weight,
		            int daysToManufacture,
		            string productLine,
		            string @class,
		            string style,
		            Nullable<int> productSubcategoryID,
		            Nullable<int> productModelID,
		            DateTime sellStartDate,
		            Nullable<DateTime> sellEndDate,
		            Nullable<DateTime> discontinuedDate,
		            Guid rowguid,
		            DateTime modifiedDate);

		void Delete(int productID);

		Response GetById(int productID);

		POCOProduct GetByIdDirect(int productID);

		Response GetWhere(Expression<Func<EFProduct, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOProduct> GetWhereDirect(Expression<Func<EFProduct, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>fedeee0bff2b7f1443364b9b0de6148a</Hash>
</Codenesium>*/