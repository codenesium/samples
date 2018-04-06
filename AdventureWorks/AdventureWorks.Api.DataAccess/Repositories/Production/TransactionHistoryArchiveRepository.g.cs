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
	public abstract class AbstractTransactionHistoryArchiveRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractTransactionHistoryArchiveRepository(ILogger logger,
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
			var record = new EFTransactionHistoryArchive ();

			MapPOCOToEF(0, productID,
			            referenceOrderID,
			            referenceOrderLineID,
			            transactionDate,
			            transactionType,
			            quantity,
			            actualCost,
			            modifiedDate, record);

			this._context.Set<EFTransactionHistoryArchive>().Add(record);
			this._context.SaveChanges();
			return record.TransactionID;
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
			var record =  this.SearchLinqEF(x => x.TransactionID == transactionID).FirstOrDefault();
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
			var record = this.SearchLinqEF(x => x.TransactionID == transactionID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFTransactionHistoryArchive>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int transactionID, Response response)
		{
			this.SearchLinqPOCO(x => x.TransactionID == transactionID,response);
		}

		protected virtual List<EFTransactionHistoryArchive> SearchLinqEF(Expression<Func<EFTransactionHistoryArchive, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFTransactionHistoryArchive> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFTransactionHistoryArchive, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFTransactionHistoryArchive, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFTransactionHistoryArchive> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFTransactionHistoryArchive> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int transactionID, int productID,
		                               int referenceOrderID,
		                               int referenceOrderLineID,
		                               DateTime transactionDate,
		                               string transactionType,
		                               int quantity,
		                               decimal actualCost,
		                               DateTime modifiedDate, EFTransactionHistoryArchive   efTransactionHistoryArchive)
		{
			efTransactionHistoryArchive.TransactionID = transactionID;
			efTransactionHistoryArchive.ProductID = productID;
			efTransactionHistoryArchive.ReferenceOrderID = referenceOrderID;
			efTransactionHistoryArchive.ReferenceOrderLineID = referenceOrderLineID;
			efTransactionHistoryArchive.TransactionDate = transactionDate;
			efTransactionHistoryArchive.TransactionType = transactionType;
			efTransactionHistoryArchive.Quantity = quantity;
			efTransactionHistoryArchive.ActualCost = actualCost;
			efTransactionHistoryArchive.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFTransactionHistoryArchive efTransactionHistoryArchive,Response response)
		{
			if(efTransactionHistoryArchive == null)
			{
				return;
			}
			response.AddTransactionHistoryArchive(new POCOTransactionHistoryArchive()
			{
				TransactionID = efTransactionHistoryArchive.TransactionID.ToInt(),
				ProductID = efTransactionHistoryArchive.ProductID.ToInt(),
				ReferenceOrderID = efTransactionHistoryArchive.ReferenceOrderID.ToInt(),
				ReferenceOrderLineID = efTransactionHistoryArchive.ReferenceOrderLineID.ToInt(),
				TransactionDate = efTransactionHistoryArchive.TransactionDate.ToDateTime(),
				TransactionType = efTransactionHistoryArchive.TransactionType,
				Quantity = efTransactionHistoryArchive.Quantity.ToInt(),
				ActualCost = efTransactionHistoryArchive.ActualCost,
				ModifiedDate = efTransactionHistoryArchive.ModifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>18b8d7ed3d6f29e58b2576d3555070f3</Hash>
</Codenesium>*/