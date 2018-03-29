using System;
using System.Linq.Expressions;
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

		void GetById(int productID, Response response);

		void GetWhere(Expression<Func<EFProduct, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a5e65a2cc49acc0482ec231754a36827</Hash>
</Codenesium>*/