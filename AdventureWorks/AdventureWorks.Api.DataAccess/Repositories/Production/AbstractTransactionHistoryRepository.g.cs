using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractTransactionHistoryRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractTransactionHistoryRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOTransactionHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOTransactionHistory> Get(int transactionID)
		{
			TransactionHistory record = await this.GetById(transactionID);

			return this.Mapper.TransactionHistoryMapEFToPOCO(record);
		}

		public async virtual Task<POCOTransactionHistory> Create(
			ApiTransactionHistoryModel model)
		{
			TransactionHistory record = new TransactionHistory();

			this.Mapper.TransactionHistoryMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<TransactionHistory>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.TransactionHistoryMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int transactionID,
			ApiTransactionHistoryModel model)
		{
			TransactionHistory record = await this.GetById(transactionID);

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
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int transactionID)
		{
			TransactionHistory record = await this.GetById(transactionID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<TransactionHistory>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<List<POCOTransactionHistory>> GetProductID(int productID)
		{
			var records = await this.SearchLinqPOCO(x => x.ProductID == productID);

			return records;
		}
		public async Task<List<POCOTransactionHistory>> GetReferenceOrderIDReferenceOrderLineID(int referenceOrderID,int referenceOrderLineID)
		{
			var records = await this.SearchLinqPOCO(x => x.ReferenceOrderID == referenceOrderID && x.ReferenceOrderLineID == referenceOrderLineID);

			return records;
		}

		protected async Task<List<POCOTransactionHistory>> Where(Expression<Func<TransactionHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOTransactionHistory> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOTransactionHistory>> SearchLinqPOCO(Expression<Func<TransactionHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOTransactionHistory> response = new List<POCOTransactionHistory>();
			List<TransactionHistory> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.TransactionHistoryMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<TransactionHistory>> SearchLinqEF(Expression<Func<TransactionHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(TransactionHistory.TransactionID)} ASC";
			}
			return await this.Context.Set<TransactionHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<TransactionHistory>();
		}

		private async Task<List<TransactionHistory>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(TransactionHistory.TransactionID)} ASC";
			}

			return await this.Context.Set<TransactionHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<TransactionHistory>();
		}

		private async Task<TransactionHistory> GetById(int transactionID)
		{
			List<TransactionHistory> records = await this.SearchLinqEF(x => x.TransactionID == transactionID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>f8bd4e3648f86658a80049ba6b5ae81a</Hash>
</Codenesium>*/