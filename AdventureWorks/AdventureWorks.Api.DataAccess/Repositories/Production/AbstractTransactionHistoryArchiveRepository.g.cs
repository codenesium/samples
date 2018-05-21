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
	public abstract class AbstractTransactionHistoryArchiveRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractTransactionHistoryArchiveRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOTransactionHistoryArchive>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOTransactionHistoryArchive> Get(int transactionID)
		{
			TransactionHistoryArchive record = await this.GetById(transactionID);

			return this.Mapper.TransactionHistoryArchiveMapEFToPOCO(record);
		}

		public async virtual Task<POCOTransactionHistoryArchive> Create(
			ApiTransactionHistoryArchiveModel model)
		{
			TransactionHistoryArchive record = new TransactionHistoryArchive();

			this.Mapper.TransactionHistoryArchiveMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<TransactionHistoryArchive>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.TransactionHistoryArchiveMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int transactionID,
			ApiTransactionHistoryArchiveModel model)
		{
			TransactionHistoryArchive record = await this.GetById(transactionID);

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

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int transactionID)
		{
			TransactionHistoryArchive record = await this.GetById(transactionID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<TransactionHistoryArchive>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<List<POCOTransactionHistoryArchive>> GetProductID(int productID)
		{
			var records = await this.SearchLinqPOCO(x => x.ProductID == productID);

			return records;
		}
		public async Task<List<POCOTransactionHistoryArchive>> GetReferenceOrderIDReferenceOrderLineID(int referenceOrderID,int referenceOrderLineID)
		{
			var records = await this.SearchLinqPOCO(x => x.ReferenceOrderID == referenceOrderID && x.ReferenceOrderLineID == referenceOrderLineID);

			return records;
		}

		protected async Task<List<POCOTransactionHistoryArchive>> Where(Expression<Func<TransactionHistoryArchive, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOTransactionHistoryArchive> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOTransactionHistoryArchive>> SearchLinqPOCO(Expression<Func<TransactionHistoryArchive, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOTransactionHistoryArchive> response = new List<POCOTransactionHistoryArchive>();
			List<TransactionHistoryArchive> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.TransactionHistoryArchiveMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<TransactionHistoryArchive>> SearchLinqEF(Expression<Func<TransactionHistoryArchive, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(TransactionHistoryArchive.TransactionID)} ASC";
			}
			return await this.Context.Set<TransactionHistoryArchive>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<TransactionHistoryArchive>();
		}

		private async Task<List<TransactionHistoryArchive>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(TransactionHistoryArchive.TransactionID)} ASC";
			}

			return await this.Context.Set<TransactionHistoryArchive>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<TransactionHistoryArchive>();
		}

		private async Task<TransactionHistoryArchive> GetById(int transactionID)
		{
			List<TransactionHistoryArchive> records = await this.SearchLinqEF(x => x.TransactionID == transactionID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>3445958eed2658115c78f49e4d5fb516</Hash>
</Codenesium>*/