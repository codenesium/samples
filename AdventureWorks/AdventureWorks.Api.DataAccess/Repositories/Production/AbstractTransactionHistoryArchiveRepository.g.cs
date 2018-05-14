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
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractTransactionHistoryArchiveRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOTransactionHistoryArchive> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOTransactionHistoryArchive Get(int transactionID)
		{
			return this.SearchLinqPOCO(x => x.TransactionID == transactionID).FirstOrDefault();
		}

		public virtual POCOTransactionHistoryArchive Create(
			ApiTransactionHistoryArchiveModel model)
		{
			TransactionHistoryArchive record = new TransactionHistoryArchive();

			this.Mapper.TransactionHistoryArchiveMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<TransactionHistoryArchive>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.TransactionHistoryArchiveMapEFToPOCO(record);
		}

		public virtual void Update(
			int transactionID,
			ApiTransactionHistoryArchiveModel model)
		{
			TransactionHistoryArchive record = this.SearchLinqEF(x => x.TransactionID == transactionID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{transactionID}");
			}
			else
			{
				this.Mapper.TransactionHistoryArchiveMapModelToEF(
					transactionID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int transactionID)
		{
			TransactionHistoryArchive record = this.SearchLinqEF(x => x.TransactionID == transactionID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<TransactionHistoryArchive>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public List<POCOTransactionHistoryArchive> GetProductID(int productID)
		{
			return this.SearchLinqPOCO(x => x.ProductID == productID);
		}
		public List<POCOTransactionHistoryArchive> GetReferenceOrderIDReferenceOrderLineID(int referenceOrderID,int referenceOrderLineID)
		{
			return this.SearchLinqPOCO(x => x.ReferenceOrderID == referenceOrderID && x.ReferenceOrderLineID == referenceOrderLineID);
		}

		protected List<POCOTransactionHistoryArchive> Where(Expression<Func<TransactionHistoryArchive, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOTransactionHistoryArchive> SearchLinqPOCO(Expression<Func<TransactionHistoryArchive, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOTransactionHistoryArchive> response = new List<POCOTransactionHistoryArchive>();
			List<TransactionHistoryArchive> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.TransactionHistoryArchiveMapEFToPOCO(x)));
			return response;
		}

		private List<TransactionHistoryArchive> SearchLinqEF(Expression<Func<TransactionHistoryArchive, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(TransactionHistoryArchive.TransactionID)} ASC";
			}
			return this.Context.Set<TransactionHistoryArchive>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<TransactionHistoryArchive>();
		}

		private List<TransactionHistoryArchive> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(TransactionHistoryArchive.TransactionID)} ASC";
			}

			return this.Context.Set<TransactionHistoryArchive>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<TransactionHistoryArchive>();
		}
	}
}

/*<Codenesium>
    <Hash>1d63ed9b7c333f377daa3cfd3ab90c8a</Hash>
</Codenesium>*/