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
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractTransactionHistoryArchiveRepository(ILogger logger,
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
			var record = new EFTransactionHistoryArchive ();

			MapPOCOToEF(0, productID,
			            referenceOrderID,
			            referenceOrderLineID,
			            transactionDate,
			            transactionType,
			            quantity,
			            actualCost,
			            modifiedDate, record);

			this.context.Set<EFTransactionHistoryArchive>().Add(record);
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
				this.logger.LogError($"Unable to find id:{transactionID}");
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
				this.context.Set<EFTransactionHistoryArchive>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(int transactionID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.TransactionID == transactionID,response);
			return response;
		}

		public virtual POCOTransactionHistoryArchive GetByIdDirect(int transactionID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.TransactionID == transactionID,response);
			return response.TransactionHistoryArchives.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFTransactionHistoryArchive, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
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

		public virtual List<POCOTransactionHistoryArchive> GetWhereDirect(Expression<Func<EFTransactionHistoryArchive, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.TransactionHistoryArchives;
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

		protected virtual List<EFTransactionHistoryArchive> SearchLinqEF(Expression<Func<EFTransactionHistoryArchive, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFTransactionHistoryArchive> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
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
		                               DateTime modifiedDate, EFTransactionHistoryArchive   efTransactionHistoryArchive)
		{
			efTransactionHistoryArchive.SetProperties(transactionID.ToInt(),productID.ToInt(),referenceOrderID.ToInt(),referenceOrderLineID.ToInt(),transactionDate.ToDateTime(),transactionType,quantity.ToInt(),actualCost,modifiedDate.ToDateTime());
		}

		public static void MapEFToPOCO(EFTransactionHistoryArchive efTransactionHistoryArchive,Response response)
		{
			if(efTransactionHistoryArchive == null)
			{
				return;
			}
			response.AddTransactionHistoryArchive(new POCOTransactionHistoryArchive(efTransactionHistoryArchive.TransactionID.ToInt(),efTransactionHistoryArchive.ProductID.ToInt(),efTransactionHistoryArchive.ReferenceOrderID.ToInt(),efTransactionHistoryArchive.ReferenceOrderLineID.ToInt(),efTransactionHistoryArchive.TransactionDate.ToDateTime(),efTransactionHistoryArchive.TransactionType,efTransactionHistoryArchive.Quantity.ToInt(),efTransactionHistoryArchive.ActualCost,efTransactionHistoryArchive.ModifiedDate.ToDateTime()));
		}
	}
}

/*<Codenesium>
    <Hash>4c24355c0e442343903b4f04073022a8</Hash>
</Codenesium>*/