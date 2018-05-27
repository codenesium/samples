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
	public abstract class AbstractSalesPersonQuotaHistoryRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IDALSalesPersonQuotaHistoryMapper Mapper { get; }

		public AbstractSalesPersonQuotaHistoryRepository(
			IDALSalesPersonQuotaHistoryMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOSalesPersonQuotaHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOSalesPersonQuotaHistory> Get(int businessEntityID)
		{
			SalesPersonQuotaHistory record = await this.GetById(businessEntityID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOSalesPersonQuotaHistory> Create(
			DTOSalesPersonQuotaHistory dto)
		{
			SalesPersonQuotaHistory record = new SalesPersonQuotaHistory();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<SalesPersonQuotaHistory>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int businessEntityID,
			DTOSalesPersonQuotaHistory dto)
		{
			SalesPersonQuotaHistory record = await this.GetById(businessEntityID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{businessEntityID}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					businessEntityID,
					dto,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int businessEntityID)
		{
			SalesPersonQuotaHistory record = await this.GetById(businessEntityID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SalesPersonQuotaHistory>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<DTOSalesPersonQuotaHistory>> Where(Expression<Func<SalesPersonQuotaHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOSalesPersonQuotaHistory> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOSalesPersonQuotaHistory>> SearchLinqDTO(Expression<Func<SalesPersonQuotaHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOSalesPersonQuotaHistory> response = new List<DTOSalesPersonQuotaHistory>();
			List<SalesPersonQuotaHistory> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
			return response;
		}

		private async Task<List<SalesPersonQuotaHistory>> SearchLinqEF(Expression<Func<SalesPersonQuotaHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SalesPersonQuotaHistory.BusinessEntityID)} ASC";
			}
			return await this.Context.Set<SalesPersonQuotaHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SalesPersonQuotaHistory>();
		}

		private async Task<List<SalesPersonQuotaHistory>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SalesPersonQuotaHistory.BusinessEntityID)} ASC";
			}

			return await this.Context.Set<SalesPersonQuotaHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SalesPersonQuotaHistory>();
		}

		private async Task<SalesPersonQuotaHistory> GetById(int businessEntityID)
		{
			List<SalesPersonQuotaHistory> records = await this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>edc1c3b211da31b098a3be7a6d6f8fad</Hash>
</Codenesium>*/