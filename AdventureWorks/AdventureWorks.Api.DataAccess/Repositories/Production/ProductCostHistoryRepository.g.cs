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
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractProductCostHistoryRepository(ILogger logger,
		                                            ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
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

			this._context.Set<EFProductCostHistory>().Add(record);
			this._context.SaveChanges();
			return record.productID;
		}

		public virtual void Update(int productID, DateTime startDate,
		                           Nullable<DateTime> endDate,
		                           decimal standardCost,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.productID == productID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",productID);
			}
			else
			{
				MapPOCOToEF(productID,  startDate,
				            endDate,
				            standardCost,
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
				this._context.Set<EFProductCostHistory>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int productID, Response response)
		{
			this.SearchLinqPOCO(x => x.productID == productID,response);
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
			efProductCostHistory.productID = productID;
			efProductCostHistory.startDate = startDate;
			efProductCostHistory.endDate = endDate;
			efProductCostHistory.standardCost = standardCost;
			efProductCostHistory.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFProductCostHistory efProductCostHistory,Response response)
		{
			if(efProductCostHistory == null)
			{
				return;
			}
			response.AddProductCostHistory(new POCOProductCostHistory()
			{
				ProductID = efProductCostHistory.productID.ToInt(),
				StartDate = efProductCostHistory.startDate.ToDateTime(),
				EndDate = efProductCostHistory.endDate.ToNullableDateTime(),
				StandardCost = efProductCostHistory.standardCost,
				ModifiedDate = efProductCostHistory.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>7fe963ef41cb5bfc9edead52c5cb6daf</Hash>
</Codenesium>*/