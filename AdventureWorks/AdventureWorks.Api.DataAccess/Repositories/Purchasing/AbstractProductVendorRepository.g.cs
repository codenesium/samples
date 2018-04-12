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
	public abstract class AbstractProductVendorRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractProductVendorRepository(
			ILogger logger,
			ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			int businessEntityID,
			int averageLeadTime,
			decimal standardPrice,
			Nullable<decimal> lastReceiptCost,
			Nullable<DateTime> lastReceiptDate,
			int minOrderQty,
			int maxOrderQty,
			Nullable<int> onOrderQty,
			string unitMeasureCode,
			DateTime modifiedDate)
		{
			var record = new EFProductVendor();

			MapPOCOToEF(
				0,
				businessEntityID,
				averageLeadTime,
				standardPrice,
				lastReceiptCost,
				lastReceiptDate,
				minOrderQty,
				maxOrderQty,
				onOrderQty,
				unitMeasureCode,
				modifiedDate,
				record);

			this.context.Set<EFProductVendor>().Add(record);
			this.context.SaveChanges();
			return record.ProductID;
		}

		public virtual void Update(
			int productID,
			int businessEntityID,
			int averageLeadTime,
			decimal standardPrice,
			Nullable<decimal> lastReceiptCost,
			Nullable<DateTime> lastReceiptDate,
			int minOrderQty,
			int maxOrderQty,
			Nullable<int> onOrderQty,
			string unitMeasureCode,
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
					businessEntityID,
					averageLeadTime,
					standardPrice,
					lastReceiptCost,
					lastReceiptDate,
					minOrderQty,
					maxOrderQty,
					onOrderQty,
					unitMeasureCode,
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
				this.context.Set<EFProductVendor>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(int productID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.ProductID == productID, response);
			return response;
		}

		public virtual POCOProductVendor GetByIdDirect(int productID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.ProductID == productID, response);
			return response.ProductVendors.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFProductVendor, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
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

		public virtual List<POCOProductVendor> GetWhereDirect(Expression<Func<EFProductVendor, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.ProductVendors;
		}

		private void SearchLinqPOCO(Expression<Func<EFProductVendor, bool>> predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFProductVendor> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFProductVendor> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		protected virtual List<EFProductVendor> SearchLinqEF(Expression<Func<EFProductVendor, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFProductVendor> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(
			int productID,
			int businessEntityID,
			int averageLeadTime,
			decimal standardPrice,
			Nullable<decimal> lastReceiptCost,
			Nullable<DateTime> lastReceiptDate,
			int minOrderQty,
			int maxOrderQty,
			Nullable<int> onOrderQty,
			string unitMeasureCode,
			DateTime modifiedDate,
			EFProductVendor efProductVendor)
		{
			efProductVendor.SetProperties(productID.ToInt(), businessEntityID.ToInt(), averageLeadTime.ToInt(), standardPrice, lastReceiptCost, lastReceiptDate.ToNullableDateTime(), minOrderQty.ToInt(), maxOrderQty.ToInt(), onOrderQty.ToNullableInt(), unitMeasureCode, modifiedDate.ToDateTime());
		}

		public static void MapEFToPOCO(
			EFProductVendor efProductVendor,
			Response response)
		{
			if (efProductVendor == null)
			{
				return;
			}

			response.AddProductVendor(new POCOProductVendor(efProductVendor.ProductID.ToInt(), efProductVendor.BusinessEntityID.ToInt(), efProductVendor.AverageLeadTime.ToInt(), efProductVendor.StandardPrice, efProductVendor.LastReceiptCost, efProductVendor.LastReceiptDate.ToNullableDateTime(), efProductVendor.MinOrderQty.ToInt(), efProductVendor.MaxOrderQty.ToInt(), efProductVendor.OnOrderQty.ToNullableInt(), efProductVendor.UnitMeasureCode, efProductVendor.ModifiedDate.ToDateTime()));

			ProductRepository.MapEFToPOCO(efProductVendor.Product, response);

			VendorRepository.MapEFToPOCO(efProductVendor.Vendor, response);

			UnitMeasureRepository.MapEFToPOCO(efProductVendor.UnitMeasure, response);
		}
	}
}

/*<Codenesium>
    <Hash>b177cbda6aa8b3fd0c333f6b687f308f</Hash>
</Codenesium>*/