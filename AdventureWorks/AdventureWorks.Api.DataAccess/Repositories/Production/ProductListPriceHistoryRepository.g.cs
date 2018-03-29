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
	public abstract class AbstractProductListPriceHistoryRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractProductListPriceHistoryRepository(ILogger logger,
		                                                 ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(DateTime startDate,
		                          Nullable<DateTime> endDate,
		                          decimal listPrice,
		                          DateTime modifiedDate)
		{
			var record = new EFProductListPriceHistory ();

			MapPOCOToEF(0, startDate,
			            endDate,
			            listPrice,
			            modifiedDate, record);

			this._context.Set<EFProductListPriceHistory>().Add(record);
			this._context.SaveChanges();
			return record.ProductID;
		}

		public virtual void Update(int productID, DateTime startDate,
		                           Nullable<DateTime> endDate,
		                           decimal listPrice,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.ProductID == productID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",productID);
			}
			else
			{
				MapPOCOToEF(productID,  startDate,
				            endDate,
				            listPrice,
				            modifiedDate, record);
				this._context.SaveChanges();
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
				this._context.Set<EFProductListPriceHistory>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int productID, Response response)
		{
			this.SearchLinqPOCO(x => x.ProductID == productID,response);
		}

		protected virtual List<EFProductListPriceHistory> SearchLinqEF(Expression<Func<EFProductListPriceHistory, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFProductListPriceHistory> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFProductListPriceHistory, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFProductListPriceHistory, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFProductListPriceHistory> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFProductListPriceHistory> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int productID, DateTime startDate,
		                               Nullable<DateTime> endDate,
		                               decimal listPrice,
		                               DateTime modifiedDate, EFProductListPriceHistory   efProductListPriceHistory)
		{
			efProductListPriceHistory.ProductID = productID;
			efProductListPriceHistory.StartDate = startDate;
			efProductListPriceHistory.EndDate = endDate;
			efProductListPriceHistory.ListPrice = listPrice;
			efProductListPriceHistory.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFProductListPriceHistory efProductListPriceHistory,Response response)
		{
			if(efProductListPriceHistory == null)
			{
				return;
			}
			response.AddProductListPriceHistory(new POCOProductListPriceHistory()
			{
				StartDate = efProductListPriceHistory.StartDate.ToDateTime(),
				EndDate = efProductListPriceHistory.EndDate.ToNullableDateTime(),
				ListPrice = efProductListPriceHistory.ListPrice,
				ModifiedDate = efProductListPriceHistory.ModifiedDate.ToDateTime(),

				ProductID = new ReferenceEntity<int>(efProductListPriceHistory.ProductID,
				                                     "Products"),
			});

			ProductRepository.MapEFToPOCO(efProductListPriceHistory.ProductRef, response);
		}
	}
}

/*<Codenesium>
    <Hash>56b02cf2437a258e1c161a477104309f</Hash>
</Codenesium>*/