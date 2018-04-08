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
	public abstract class AbstractProductCostHistoryRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractProductCostHistoryRepository(ILogger logger,
		                                            ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(DateTime startDate,
		                          Nullable<DateTime> endDate,
		                          decimal standardCost,
		                          DateTime modifiedDate)
		{
			var record = new EFProductCostHistory ();

			MapPOCOToEF(0, startDate,
			            endDate,
			            standardCost,
			            modifiedDate, record);

			this.context.Set<EFProductCostHistory>().Add(record);
			this.context.SaveChanges();
			return record.ProductID;
		}

		public virtual void Update(int productID, DateTime startDate,
		                           Nullable<DateTime> endDate,
		                           decimal standardCost,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.ProductID == productID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",productID);
			}
			else
			{
				MapPOCOToEF(productID,  startDate,
				            endDate,
				            standardCost,
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
				this.context.Set<EFProductCostHistory>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual void GetById(int productID, Response response)
		{
			this.SearchLinqPOCO(x => x.ProductID == productID,response);
		}

		protected virtual List<EFProductCostHistory> SearchLinqEF(Expression<Func<EFProductCostHistory, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFProductCostHistory> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFProductCostHistory, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		public virtual List<POCOProductCostHistory> GetWhereDirect(Expression<Func<EFProductCostHistory, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.ProductCostHistories;
		}
		public virtual POCOProductCostHistory GetByIdDirect(int productID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.ProductID == productID,response);
			return response.ProductCostHistories.FirstOrDefault();
		}

		private void SearchLinqPOCO(Expression<Func<EFProductCostHistory, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFProductCostHistory> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFProductCostHistory> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int productID, DateTime startDate,
		                               Nullable<DateTime> endDate,
		                               decimal standardCost,
		                               DateTime modifiedDate, EFProductCostHistory   efProductCostHistory)
		{
			efProductCostHistory.ProductID = productID;
			efProductCostHistory.StartDate = startDate;
			efProductCostHistory.EndDate = endDate;
			efProductCostHistory.StandardCost = standardCost;
			efProductCostHistory.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFProductCostHistory efProductCostHistory,Response response)
		{
			if(efProductCostHistory == null)
			{
				return;
			}
			response.AddProductCostHistory(new POCOProductCostHistory()
			{
				StartDate = efProductCostHistory.StartDate.ToDateTime(),
				EndDate = efProductCostHistory.EndDate.ToNullableDateTime(),
				StandardCost = efProductCostHistory.StandardCost,
				ModifiedDate = efProductCostHistory.ModifiedDate.ToDateTime(),

				ProductID = new ReferenceEntity<int>(efProductCostHistory.ProductID,
				                                     "Products"),
			});

			ProductRepository.MapEFToPOCO(efProductCostHistory.Product, response);
		}
	}
}

/*<Codenesium>
    <Hash>add2990c21b83993cf6c668eee8e1b95</Hash>
</Codenesium>*/