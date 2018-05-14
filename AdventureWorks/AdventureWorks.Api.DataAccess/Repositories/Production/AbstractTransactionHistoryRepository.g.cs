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
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractTransactionHistoryRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOTransactionHistory> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOTransactionHistory Get(int transactionID)
		{
			return this.SearchLinqPOCO(x => x.TransactionID == transactionID).FirstOrDefault();
		}

		public virtual POCOTransactionHistory Create(
			ApiTransactionHistoryModel model)
		{
			TransactionHistory record = new TransactionHistory();

			this.Mapper.TransactionHistoryMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<TransactionHistory>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.TransactionHistoryMapEFToPOCO(record);
		}

		public virtual void Update(
			int transactionID,
			ApiTransactionHistoryModel model)
		{
			TransactionHistory record = this.SearchLinqEF(x => x.TransactionID == transactionID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{transactionID}");
			}
			else
			{
				this.Mapper.TransactionHistoryMapModelToEF(
					transactionID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int transactionID)
		{
			TransactionHistory record = this.SearchLinqEF(x => x.TransactionID == transactionID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<TransactionHistory>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public List<POCOTransactionHistory> GetProductID(int productID)
		{
			return this.SearchLinqPOCO(x => x.ProductID == productID);
		}
		public List<POCOTransactionHistory> GetReferenceOrderIDReferenceOrderLineID(int referenceOrderID,int referenceOrderLineID)
		{
			return this.SearchLinqPOCO(x => x.ReferenceOrderID == referenceOrderID && x.ReferenceOrderLineID == referenceOrderLineID);
		}

		protected List<POCOTransactionHistory> Where(Expression<Func<TransactionHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOTransactionHistory> SearchLinqPOCO(Expression<Func<TransactionHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOTransactionHistory> response = new List<POCOTransactionHistory>();
			List<TransactionHistory> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.TransactionHistoryMapEFToPOCO(x)));
			return response;
		}

		private List<TransactionHistory> SearchLinqEF(Expression<Func<TransactionHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(TransactionHistory.TransactionID)} ASC";
			}
			return this.Context.Set<TransactionHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<TransactionHistory>();
		}

		private List<TransactionHistory> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(TransactionHistory.TransactionID)} ASC";
			}

			return this.Context.Set<TransactionHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<TransactionHistory>();
		}
	}
}

/*<Codenesium>
    <Hash>b6444761e860f56c1c3c5c66901ab3c3</Hash>
</Codenesium>*/