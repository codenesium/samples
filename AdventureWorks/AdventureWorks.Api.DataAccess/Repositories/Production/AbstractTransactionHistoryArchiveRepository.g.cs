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
		protected IDALTransactionHistoryArchiveMapper Mapper { get; }

		public AbstractTransactionHistoryArchiveRepository(
			IDALTransactionHistoryArchiveMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOTransactionHistoryArchive>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOTransactionHistoryArchive> Get(int transactionID)
		{
			TransactionHistoryArchive record = await this.GetById(transactionID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOTransactionHistoryArchive> Create(
			DTOTransactionHistoryArchive dto)
		{
			TransactionHistoryArchive record = new TransactionHistoryArchive();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<TransactionHistoryArchive>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int transactionID,
			DTOTransactionHistoryArchive dto)
		{
			TransactionHistoryArchive record = await this.GetById(transactionID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{transactionID}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					transactionID,
					dto,
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

		public async Task<List<DTOTransactionHistoryArchive>> GetProductID(int productID)
		{
			var records = await this.SearchLinqDTO(x => x.ProductID == productID);

			return records;
		}
		public async Task<List<DTOTransactionHistoryArchive>> GetReferenceOrderIDReferenceOrderLineID(int referenceOrderID,int referenceOrderLineID)
		{
			var records = await this.SearchLinqDTO(x => x.ReferenceOrderID == referenceOrderID && x.ReferenceOrderLineID == referenceOrderLineID);

			return records;
		}

		protected async Task<List<DTOTransactionHistoryArchive>> Where(Expression<Func<TransactionHistoryArchive, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOTransactionHistoryArchive> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOTransactionHistoryArchive>> SearchLinqDTO(Expression<Func<TransactionHistoryArchive, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOTransactionHistoryArchive> response = new List<DTOTransactionHistoryArchive>();
			List<TransactionHistoryArchive> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
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
    <Hash>9d822bfe1042b2113f0a2b51c6403287</Hash>
</Codenesium>*/