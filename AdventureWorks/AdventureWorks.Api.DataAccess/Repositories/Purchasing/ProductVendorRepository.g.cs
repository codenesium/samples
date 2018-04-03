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
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractProductVendorRepository(ILogger logger,
		                                       ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(int businessEntityID,
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
			var record = new EFProductVendor ();

			MapPOCOToEF(0, businessEntityID,
			            averageLeadTime,
			            standardPrice,
			            lastReceiptCost,
			            lastReceiptDate,
			            minOrderQty,
			            maxOrderQty,
			            onOrderQty,
			            unitMeasureCode,
			            modifiedDate, record);

			this._context.Set<EFProductVendor>().Add(record);
			this._context.SaveChanges();
			return record.productID;
		}

		public virtual void Update(int productID, int businessEntityID,
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
			var record =  this.SearchLinqEF(x => x.productID == productID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",productID);
			}
			else
			{
				MapPOCOToEF(productID,  businessEntityID,
				            averageLeadTime,
				            standardPrice,
				            lastReceiptCost,
				            lastReceiptDate,
				            minOrderQty,
				            maxOrderQty,
				            onOrderQty,
				            unitMeasureCode,
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
				this._context.Set<EFProductVendor>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int productID, Response response)
		{
			this.SearchLinqPOCO(x => x.productID == productID,response);
		}

		protected virtual List<EFProductVendor> SearchLinqEF(Expression<Func<EFProductVendor, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFProductVendor> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFProductVendor, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFProductVendor, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFProductVendor> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFProductVendor> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int productID, int businessEntityID,
		                               int averageLeadTime,
		                               decimal standardPrice,
		                               Nullable<decimal> lastReceiptCost,
		                               Nullable<DateTime> lastReceiptDate,
		                               int minOrderQty,
		                               int maxOrderQty,
		                               Nullable<int> onOrderQty,
		                               string unitMeasureCode,
		                               DateTime modifiedDate, EFProductVendor   efProductVendor)
		{
			efProductVendor.productID = productID;
			efProductVendor.businessEntityID = businessEntityID;
			efProductVendor.averageLeadTime = averageLeadTime;
			efProductVendor.standardPrice = standardPrice;
			efProductVendor.lastReceiptCost = lastReceiptCost;
			efProductVendor.lastReceiptDate = lastReceiptDate;
			efProductVendor.minOrderQty = minOrderQty;
			efProductVendor.maxOrderQty = maxOrderQty;
			efProductVendor.onOrderQty = onOrderQty;
			efProductVendor.unitMeasureCode = unitMeasureCode;
			efProductVendor.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFProductVendor efProductVendor,Response response)
		{
			if(efProductVendor == null)
			{
				return;
			}
			response.AddProductVendor(new POCOProductVendor()
			{
				ProductID = efProductVendor.productID.ToInt(),
				BusinessEntityID = efProductVendor.businessEntityID.ToInt(),
				AverageLeadTime = efProductVendor.averageLeadTime.ToInt(),
				StandardPrice = efProductVendor.standardPrice,
				LastReceiptCost = efProductVendor.lastReceiptCost,
				LastReceiptDate = efProductVendor.lastReceiptDate.ToNullableDateTime(),
				MinOrderQty = efProductVendor.minOrderQty.ToInt(),
				MaxOrderQty = efProductVendor.maxOrderQty.ToInt(),
				OnOrderQty = efProductVendor.onOrderQty.ToNullableInt(),
				UnitMeasureCode = efProductVendor.unitMeasureCode,
				ModifiedDate = efProductVendor.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>b14f35a580005c43f081b0ed3e8a52a7</Hash>
</Codenesium>*/