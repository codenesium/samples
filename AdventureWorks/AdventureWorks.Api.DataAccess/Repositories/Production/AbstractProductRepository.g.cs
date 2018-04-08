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
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractProductRepository(ILogger logger,
		                                 ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
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

			this.context.Set<EFProduct>().Add(record);
			this.context.SaveChanges();
			return record.ProductID;
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
			var record =  this.SearchLinqEF(x => x.ProductID == productID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",productID);
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
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(int productID)
		{
			var record = this.SearchLinqEF(x => x.ProductID == productID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFProduct>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual void GetById(int productID, Response response)
		{
			this.SearchLinqPOCO(x => x.ProductID == productID,response);
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

		public virtual List<POCOProduct > GetWhereDirect(Expression<Func<EFProduct, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.Products;
		}
		public virtual POCOProduct GetByIdDirect(int productID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.ProductID == productID,response);
			return response.Products.FirstOrDefault();
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
			efProduct.ProductID = productID;
			efProduct.Name = name;
			efProduct.ProductNumber = productNumber;
			efProduct.MakeFlag = makeFlag;
			efProduct.FinishedGoodsFlag = finishedGoodsFlag;
			efProduct.Color = color;
			efProduct.SafetyStockLevel = safetyStockLevel;
			efProduct.ReorderPoint = reorderPoint;
			efProduct.StandardCost = standardCost;
			efProduct.ListPrice = listPrice;
			efProduct.Size = size;
			efProduct.SizeUnitMeasureCode = sizeUnitMeasureCode;
			efProduct.WeightUnitMeasureCode = weightUnitMeasureCode;
			efProduct.Weight = weight;
			efProduct.DaysToManufacture = daysToManufacture;
			efProduct.ProductLine = productLine;
			efProduct.@Class = @class;
			efProduct.Style = style;
			efProduct.ProductSubcategoryID = productSubcategoryID;
			efProduct.ProductModelID = productModelID;
			efProduct.SellStartDate = sellStartDate;
			efProduct.SellEndDate = sellEndDate;
			efProduct.DiscontinuedDate = discontinuedDate;
			efProduct.Rowguid = rowguid;
			efProduct.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFProduct efProduct,Response response)
		{
			if(efProduct == null)
			{
				return;
			}
			response.AddProduct(new POCOProduct()
			{
				ProductID = efProduct.ProductID.ToInt(),
				Name = efProduct.Name,
				ProductNumber = efProduct.ProductNumber,
				MakeFlag = efProduct.MakeFlag,
				FinishedGoodsFlag = efProduct.FinishedGoodsFlag,
				Color = efProduct.Color,
				SafetyStockLevel = efProduct.SafetyStockLevel,
				ReorderPoint = efProduct.ReorderPoint,
				StandardCost = efProduct.StandardCost,
				ListPrice = efProduct.ListPrice,
				Size = efProduct.Size,
				Weight = efProduct.Weight.ToNullableDecimal(),
				DaysToManufacture = efProduct.DaysToManufacture.ToInt(),
				ProductLine = efProduct.ProductLine,
				@Class = efProduct.@Class,
				Style = efProduct.Style,
				SellStartDate = efProduct.SellStartDate.ToDateTime(),
				SellEndDate = efProduct.SellEndDate.ToNullableDateTime(),
				DiscontinuedDate = efProduct.DiscontinuedDate.ToNullableDateTime(),
				Rowguid = efProduct.Rowguid,
				ModifiedDate = efProduct.ModifiedDate.ToDateTime(),

				SizeUnitMeasureCode = new ReferenceEntity<string>(efProduct.SizeUnitMeasureCode,
				                                                  "UnitMeasures"),
				WeightUnitMeasureCode = new ReferenceEntity<string>(efProduct.WeightUnitMeasureCode,
				                                                    "UnitMeasures"),
				ProductSubcategoryID = new ReferenceEntity<Nullable<int>>(efProduct.ProductSubcategoryID,
				                                                          "ProductSubcategories"),
				ProductModelID = new ReferenceEntity<Nullable<int>>(efProduct.ProductModelID,
				                                                    "ProductModels"),
			});

			UnitMeasureRepository.MapEFToPOCO(efProduct.UnitMeasure, response);

			UnitMeasureRepository.MapEFToPOCO(efProduct.UnitMeasure1, response);

			ProductSubcategoryRepository.MapEFToPOCO(efProduct.ProductSubcategory, response);

			ProductModelRepository.MapEFToPOCO(efProduct.ProductModel, response);
		}
	}
}

/*<Codenesium>
    <Hash>88a82fc89418e57678957c833023fb52</Hash>
</Codenesium>*/