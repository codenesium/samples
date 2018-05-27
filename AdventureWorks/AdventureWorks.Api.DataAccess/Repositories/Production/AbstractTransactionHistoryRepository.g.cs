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
		protected IDALTransactionHistoryMapper Mapper { get; }

		public AbstractTransactionHistoryRepository(
			IDALTransactionHistoryMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOTransactionHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOTransactionHistory> Get(int transactionID)
		{
			TransactionHistory record = await this.GetById(transactionID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOTransactionHistory> Create(
			DTOTransactionHistory dto)
		{
			TransactionHistory record = new TransactionHistory();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<TransactionHistory>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int transactionID,
			DTOTransactionHistory dto)
		{
			TransactionHistory record = await this.GetById(transactionID);

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

		public async Task<List<DTOTransactionHistory>> GetProductID(int productID)
		{
			var records = await this.SearchLinqDTO(x => x.ProductID == productID);

			return records;
		}
		public async Task<List<DTOTransactionHistory>> GetReferenceOrderIDReferenceOrderLineID(int referenceOrderID,int referenceOrderLineID)
		{
			var records = await this.SearchLinqDTO(x => x.ReferenceOrderID == referenceOrderID && x.ReferenceOrderLineID == referenceOrderLineID);

			return records;
		}

		protected async Task<List<DTOTransactionHistory>> Where(Expression<Func<TransactionHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOTransactionHistory> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOTransactionHistory>> SearchLinqDTO(Expression<Func<TransactionHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOTransactionHistory> response = new List<DTOTransactionHistory>();
			List<TransactionHistory> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
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
    <Hash>018581ffb7a6c1757bc04e55087081a8</Hash>
</Codenesium>*/