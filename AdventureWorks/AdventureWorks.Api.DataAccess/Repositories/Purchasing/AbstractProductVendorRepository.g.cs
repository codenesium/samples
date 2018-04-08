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

		public AbstractProductVendorRepository(ILogger logger,
		                                       ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
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

			this.context.Set<EFProductVendor>().Add(record);
			this.context.SaveChanges();
			return record.ProductID;
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
			var record =  this.SearchLinqEF(x => x.ProductID == productID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",productID);
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
				this.context.Set<EFProductVendor>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual void GetById(int productID, Response response)
		{
			this.SearchLinqPOCO(x => x.ProductID == productID,response);
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

		public virtual List<POCOProductVendor> GetWhereDirect(Expression<Func<EFProductVendor, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.ProductVendors;
		}
		public virtual POCOProductVendor GetByIdDirect(int productID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.ProductID == productID,response);
			return response.ProductVendors.FirstOrDefault();
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
			efProductVendor.ProductID = productID;
			efProductVendor.BusinessEntityID = businessEntityID;
			efProductVendor.AverageLeadTime = averageLeadTime;
			efProductVendor.StandardPrice = standardPrice;
			efProductVendor.LastReceiptCost = lastReceiptCost;
			efProductVendor.LastReceiptDate = lastReceiptDate;
			efProductVendor.MinOrderQty = minOrderQty;
			efProductVendor.MaxOrderQty = maxOrderQty;
			efProductVendor.OnOrderQty = onOrderQty;
			efProductVendor.UnitMeasureCode = unitMeasureCode;
			efProductVendor.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFProductVendor efProductVendor,Response response)
		{
			if(efProductVendor == null)
			{
				return;
			}
			response.AddProductVendor(new POCOProductVendor()
			{
				AverageLeadTime = efProductVendor.AverageLeadTime.ToInt(),
				StandardPrice = efProductVendor.StandardPrice,
				LastReceiptCost = efProductVendor.LastReceiptCost,
				LastReceiptDate = efProductVendor.LastReceiptDate.ToNullableDateTime(),
				MinOrderQty = efProductVendor.MinOrderQty.ToInt(),
				MaxOrderQty = efProductVendor.MaxOrderQty.ToInt(),
				OnOrderQty = efProductVendor.OnOrderQty.ToNullableInt(),
				ModifiedDate = efProductVendor.ModifiedDate.ToDateTime(),

				ProductID = new ReferenceEntity<int>(efProductVendor.ProductID,
				                                     "Products"),
				BusinessEntityID = new ReferenceEntity<int>(efProductVendor.BusinessEntityID,
				                                            "Vendors"),
				UnitMeasureCode = new ReferenceEntity<string>(efProductVendor.UnitMeasureCode,
				                                              "UnitMeasures"),
			});

			ProductRepository.MapEFToPOCO(efProductVendor.Product, response);

			VendorRepository.MapEFToPOCO(efProductVendor.Vendor, response);

			UnitMeasureRepository.MapEFToPOCO(efProductVendor.UnitMeasure, response);
		}
	}
}

/*<Codenesium>
    <Hash>a90a213de87dfe58cd7e232f7369c953</Hash>
</Codenesium>*/