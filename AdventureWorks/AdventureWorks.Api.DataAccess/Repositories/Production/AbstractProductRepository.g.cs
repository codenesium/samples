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

		public AbstractProductRepository(
			ILogger logger,
			ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			string name,
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
			var record = new EFProduct();

			MapPOCOToEF(
				0,
				name,
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
				modifiedDate,
				record);

			this.context.Set<EFProduct>().Add(record);
			this.context.SaveChanges();
			return record.ProductID;
		}

		public virtual void Update(
			int productID,
			string name,
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
			var record = this.SearchLinqEF(x => x.ProductID == productID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{productID}");
			}
			else
			{
				MapPOCOToEF(
					productID,
					name,
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
					modifiedDate,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int productID)
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

		public virtual Response GetById(int productID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.ProductID == productID, response);
			return response;
		}

		public virtual POCOProduct GetByIdDirect(int productID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.ProductID == productID, response);
			return response.Products.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFProduct, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOProduct> GetWhereDirect(Expression<Func<EFProduct, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.Products;
		}

		private void SearchLinqPOCO(Expression<Func<EFProduct, bool>> predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFProduct> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFProduct> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		protected virtual List<EFProduct> SearchLinqEF(Expression<Func<EFProduct, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFProduct> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(
			int productID,
			string name,
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
			DateTime modifiedDate,
			EFProduct efProduct)
		{
			efProduct.SetProperties(productID.ToInt(), name, productNumber, makeFlag, finishedGoodsFlag, color, safetyStockLevel, reorderPoint, standardCost, listPrice, size, sizeUnitMeasureCode, weightUnitMeasureCode, weight.ToNullableDecimal(), daysToManufacture.ToInt(), productLine, @class, style, productSubcategoryID.ToNullableInt(), productModelID.ToNullableInt(), sellStartDate.ToDateTime(), sellEndDate.ToNullableDateTime(), discontinuedDate.ToNullableDateTime(), rowguid, modifiedDate.ToDateTime());
		}

		public static void MapEFToPOCO(
			EFProduct efProduct,
			Response response)
		{
			if (efProduct == null)
			{
				return;
			}

			response.AddProduct(new POCOProduct(efProduct.ProductID.ToInt(), efProduct.Name, efProduct.ProductNumber, efProduct.MakeFlag, efProduct.FinishedGoodsFlag, efProduct.Color, efProduct.SafetyStockLevel, efProduct.ReorderPoint, efProduct.StandardCost, efProduct.ListPrice, efProduct.Size, efProduct.SizeUnitMeasureCode, efProduct.WeightUnitMeasureCode, efProduct.Weight.ToNullableDecimal(), efProduct.DaysToManufacture.ToInt(), efProduct.ProductLine, efProduct.@Class, efProduct.Style, efProduct.ProductSubcategoryID.ToNullableInt(), efProduct.ProductModelID.ToNullableInt(), efProduct.SellStartDate.ToDateTime(), efProduct.SellEndDate.ToNullableDateTime(), efProduct.DiscontinuedDate.ToNullableDateTime(), efProduct.Rowguid, efProduct.ModifiedDate.ToDateTime()));

			UnitMeasureRepository.MapEFToPOCO(efProduct.UnitMeasure, response);

			UnitMeasureRepository.MapEFToPOCO(efProduct.UnitMeasure1, response);

			ProductSubcategoryRepository.MapEFToPOCO(efProduct.ProductSubcategory, response);

			ProductModelRepository.MapEFToPOCO(efProduct.ProductModel, response);
		}
	}
}

/*<Codenesium>
    <Hash>bdca59d66bcdec03356543ee78c22f2d</Hash>
</Codenesium>*/