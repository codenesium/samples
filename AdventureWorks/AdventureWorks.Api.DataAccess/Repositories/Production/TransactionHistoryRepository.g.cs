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
	public abstract class AbstractTransactionHistoryRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractTransactionHistoryRepository(ILogger logger,
		                                            ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(int productID,
		                          int referenceOrderID,
		                          int referenceOrderLineID,
		                          DateTime transactionDate,
		                          string transactionType,
		                          int quantity,
		                          decimal actualCost,
		                          DateTime modifiedDate)
		{
			var record = new EFTransactionHistory ();

			MapPOCOToEF(0, productID,
			            referenceOrderID,
			            referenceOrderLineID,
			            transactionDate,
			            transactionType,
			            quantity,
			            actualCost,
			            modifiedDate, record);

			this._context.Set<EFTransactionHistory>().Add(record);
			this._context.SaveChanges();
			return record.transactionID;
		}

		public virtual void Update(int transactionID, int productID,
		                           int referenceOrderID,
		                           int referenceOrderLineID,
		                           DateTime transactionDate,
		                           string transactionType,
		                           int quantity,
		                           decimal actualCost,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.transactionID == transactionID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",transactionID);
			}
			else
			{
				MapPOCOToEF(transactionID,  productID,
				            referenceOrderID,
				            referenceOrderLineID,
				            transactionDate,
				            transactionType,
				            quantity,
				            actualCost,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int transactionID)
		{
			var record = this.SearchLinqEF(x => x.transactionID == transactionID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFTransactionHistory>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int transactionID, Response response)
		{
			this.SearchLinqPOCO(x => x.transactionID == transactionID,response);
		}

		protected virtual List<EFTransactionHistory> SearchLinqEF(Expression<Func<EFTransactionHistory, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFTransactionHistory> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFTransactionHistory, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFTransactionHistory, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFTransactionHistory> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFTransactionHistory> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int transactionID, int productID,
		                               int referenceOrderID,
		                               int referenceOrderLineID,
		                               DateTime transactionDate,
		                               string transactionType,
		                               int quantity,
		                               decimal actualCost,
		                               DateTime modifiedDate, EFTransactionHistory   efTransactionHistory)
		{
			efTransactionHistory.transactionID = transactionID;
			efTransactionHistory.productID = productID;
			efTransactionHistory.referenceOrderID = referenceOrderID;
			efTransactionHistory.referenceOrderLineID = referenceOrderLineID;
			efTransactionHistory.transactionDate = transactionDate;
			efTransactionHistory.transactionType = transactionType;
			efTransactionHistory.quantity = quantity;
			efTransactionHistory.actualCost = actualCost;
			efTransactionHistory.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFTransactionHistory efTransactionHistory,Response response)
		{
			if(efTransactionHistory == null)
			{
				return;
			}
			response.AddTransactionHistory(new POCOTransactionHistory()
			{
				TransactionID = efTransactionHistory.transactionID.ToInt(),
				ProductID = efTransactionHistory.productID.ToInt(),
				ReferenceOrderID = efTransactionHistory.referenceOrderID.ToInt(),
				ReferenceOrderLineID = efTransactionHistory.referenceOrderLineID.ToInt(),
				TransactionDate = efTransactionHistory.transactionDate.ToDateTime(),
				TransactionType = efTransactionHistory.transactionType,
				Quantity = efTransactionHistory.quantity.ToInt(),
				ActualCost = efTransactionHistory.actualCost,
				ModifiedDate = efTransactionHistory.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>98ea9c8fc6d2e93eb630ed70820a958e</Hash>
</Codenesium>*/