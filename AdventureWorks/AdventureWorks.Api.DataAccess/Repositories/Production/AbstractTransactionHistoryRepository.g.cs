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
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractTransactionHistoryRepository(ILogger logger,
		                                            ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
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

			this.context.Set<EFTransactionHistory>().Add(record);
			this.context.SaveChanges();
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
				this.logger.LogError("Unable to find id:{0}",transactionID);
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
				this.context.SaveChanges();
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
				this.context.Set<EFTransactionHistory>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(int transactionID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.TransactionID == transactionID,response);
			return response;
		}

		public virtual POCOTransactionHistory GetByIdDirect(int transactionID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.TransactionID == transactionID,response);
			return response.TransactionHistories.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFTransactionHistory, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOTransactionHistory> GetWhereDirect(Expression<Func<EFTransactionHistory, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.TransactionHistories;
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

		protected virtual List<EFTransactionHistory> SearchLinqEF(Expression<Func<EFTransactionHistory, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFTransactionHistory> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
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
			efTransactionHistory.TransactionID = transactionID;
			efTransactionHistory.ProductID = productID;
			efTransactionHistory.ReferenceOrderID = referenceOrderID;
			efTransactionHistory.ReferenceOrderLineID = referenceOrderLineID;
			efTransactionHistory.TransactionDate = transactionDate;
			efTransactionHistory.TransactionType = transactionType;
			efTransactionHistory.Quantity = quantity;
			efTransactionHistory.ActualCost = actualCost;
			efTransactionHistory.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFTransactionHistory efTransactionHistory,Response response)
		{
			if(efTransactionHistory == null)
			{
				return;
			}
			response.AddTransactionHistory(new POCOTransactionHistory()
			{
				TransactionID = efTransactionHistory.TransactionID.ToInt(),
				ReferenceOrderID = efTransactionHistory.ReferenceOrderID.ToInt(),
				ReferenceOrderLineID = efTransactionHistory.ReferenceOrderLineID.ToInt(),
				TransactionDate = efTransactionHistory.TransactionDate.ToDateTime(),
				TransactionType = efTransactionHistory.TransactionType,
				Quantity = efTransactionHistory.Quantity.ToInt(),
				ActualCost = efTransactionHistory.ActualCost,
				ModifiedDate = efTransactionHistory.ModifiedDate.ToDateTime(),

				ProductID = new ReferenceEntity<int>(efTransactionHistory.ProductID,
				                                     "Products"),
			});

			ProductRepository.MapEFToPOCO(efTransactionHistory.Product, response);
		}
	}
}

/*<Codenesium>
    <Hash>134b0a87fe64ccbdcfbb0d427c0bfa41</Hash>
</Codenesium>*/