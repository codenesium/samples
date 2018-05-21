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
		protected IObjectMapper Mapper { get; }

		public AbstractSalesPersonQuotaHistoryRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOSalesPersonQuotaHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOSalesPersonQuotaHistory> Get(int businessEntityID)
		{
			SalesPersonQuotaHistory record = await this.GetById(businessEntityID);

			return this.Mapper.SalesPersonQuotaHistoryMapEFToPOCO(record);
		}

		public async virtual Task<POCOSalesPersonQuotaHistory> Create(
			ApiSalesPersonQuotaHistoryModel model)
		{
			SalesPersonQuotaHistory record = new SalesPersonQuotaHistory();

			this.Mapper.SalesPersonQuotaHistoryMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<SalesPersonQuotaHistory>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.SalesPersonQuotaHistoryMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int businessEntityID,
			ApiSalesPersonQuotaHistoryModel model)
		{
			SalesPersonQuotaHistory record = await this.GetById(businessEntityID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{businessEntityID}");
			}
			else
			{
				this.Mapper.SalesPersonQuotaHistoryMapModelToEF(
					businessEntityID,
					model,
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

		protected async Task<List<POCOSalesPersonQuotaHistory>> Where(Expression<Func<SalesPersonQuotaHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSalesPersonQuotaHistory> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOSalesPersonQuotaHistory>> SearchLinqPOCO(Expression<Func<SalesPersonQuotaHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSalesPersonQuotaHistory> response = new List<POCOSalesPersonQuotaHistory>();
			List<SalesPersonQuotaHistory> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.SalesPersonQuotaHistoryMapEFToPOCO(x)));
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
    <Hash>9025566561edf42d8c76faba84f464ed</Hash>
</Codenesium>*/