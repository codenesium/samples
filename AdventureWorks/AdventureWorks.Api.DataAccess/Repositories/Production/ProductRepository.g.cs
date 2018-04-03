using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractProductRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractProductRepository(ILogger logger,
		                                 ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(string name,
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
		                          DateTime modifiedDate)
		{
			var record = new EFProduct ();

			MapPOCOToEF(0, name,
			            productNumber,
			            makeFlag,
			            finishedGoodsFlag,
			            color,
			            safetyStockLevel,
			            reorderPoint,
			            standardCost,
			            listPrice,
			            size,
			            sizeUnitMeasureCode,
			            weightUnitMeasureCode,
			            weight,
			            daysToManufacture,
			            productLine,
			            @class,
			            style,
			            productSubcategoryID,
			            productModelID,
			            sellStartDate,
			            sellEndDate,
			            discontinuedDate,
			            rowguid,
			            modifiedDate, record);

			this._context.Set<EFProduct>().Add(record);
			this._context.SaveChanges();
			return record.productID;
		}

		public virtual void Update(int productID, string name,
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
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.productID == productID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",productID);
			}
			else
			{
				MapPOCOToEF(productID,  name,
				            productNumber,
				            makeFlag,
				            finishedGoodsFlag,
				            color,
				            safetyStockLevel,
				            reorderPoint,
				            standardCost,
				            listPrice,
				            size,
				            sizeUnitMeasureCode,
				            weightUnitMeasureCode,
				            weight,
				            daysToManufacture,
				            productLine,
				            @class,
				            style,
				            productSubcategoryID,
				            productModelID,
				            sellStartDate,
				            sellEndDate,
				            discontinuedDate,
				            rowguid,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int productID)
		{
			var record = this.SearchLinqEF(x => x.productID == productID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFProduct>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int productID, Response response)
		{
			this.SearchLinqPOCO(x => x.productID == productID,response);
		}

		protected virtual List<EFProduct> SearchLinqEF(Expression<Func<EFProduct, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFProduct> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFProduct, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFProduct, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFProduct> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFProduct> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int productID, string name,
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
		                               DateTime modifiedDate, EFProduct   efProduct)
		{
			efProduct.productID = productID;
			efProduct.name = name;
			efProduct.productNumber = productNumber;
			efProduct.makeFlag = makeFlag;
			efProduct.finishedGoodsFlag = finishedGoodsFlag;
			efProduct.color = color;
			efProduct.safetyStockLevel = safetyStockLevel;
			efProduct.reorderPoint = reorderPoint;
			efProduct.standardCost = standardCost;
			efProduct.listPrice = listPrice;
			efProduct.size = size;
			efProduct.sizeUnitMeasureCode = sizeUnitMeasureCode;
			efProduct.weightUnitMeasureCode = weightUnitMeasureCode;
			efProduct.weight = weight;
			efProduct.daysToManufacture = daysToManufacture;
			efProduct.productLine = productLine;
			efProduct.@class = @class;
			efProduct.style = style;
			efProduct.productSubcategoryID = productSubcategoryID;
			efProduct.productModelID = productModelID;
			efProduct.sellStartDate = sellStartDate;
			efProduct.sellEndDate = sellEndDate;
			efProduct.discontinuedDate = discontinuedDate;
			efProduct.rowguid = rowguid;
			efProduct.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFProduct efProduct,Response response)
		{
			if(efProduct == null)
			{
				return;
			}
			response.AddProduct(new POCOProduct()
			{
				ProductID = efProduct.productID.ToInt(),
				Name = efProduct.name,
				ProductNumber = efProduct.productNumber,
				MakeFlag = efProduct.makeFlag,
				FinishedGoodsFlag = efProduct.finishedGoodsFlag,
				Color = efProduct.color,
				SafetyStockLevel = efProduct.safetyStockLevel,
				ReorderPoint = efProduct.reorderPoint,
				StandardCost = efProduct.standardCost,
				ListPrice = efProduct.listPrice,
				Size = efProduct.size,
				SizeUnitMeasureCode = efProduct.sizeUnitMeasureCode,
				WeightUnitMeasureCode = efProduct.weightUnitMeasureCode,
				Weight = efProduct.weight.ToNullableDecimal(),
				DaysToManufacture = efProduct.daysToManufacture.ToInt(),
				ProductLine = efProduct.productLine,
				@Class = efProduct.@class,
				Style = efProduct.style,
				ProductSubcategoryID = efProduct.productSubcategoryID.ToNullableInt(),
				ProductModelID = efProduct.productModelID.ToNullableInt(),
				SellStartDate = efProduct.sellStartDate.ToDateTime(),
				SellEndDate = efProduct.sellEndDate.ToNullableDateTime(),
				DiscontinuedDate = efProduct.discontinuedDate.ToNullableDateTime(),
				Rowguid = efProduct.rowguid,
				ModifiedDate = efProduct.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>936fa709cf488f5d9b020b376650d9c9</Hash>
</Codenesium>*/