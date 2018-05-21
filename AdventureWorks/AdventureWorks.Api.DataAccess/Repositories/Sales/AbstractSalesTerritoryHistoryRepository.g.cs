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
	public abstract class AbstractSalesTerritoryHistoryRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractSalesTerritoryHistoryRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOSalesTerritoryHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOSalesTerritoryHistory> Get(int businessEntityID)
		{
			SalesTerritoryHistory record = await this.GetById(businessEntityID);

			return this.Mapper.SalesTerritoryHistoryMapEFToPOCO(record);
		}

		public async virtual Task<POCOSalesTerritoryHistory> Create(
			ApiSalesTerritoryHistoryModel model)
		{
			SalesTerritoryHistory record = new SalesTerritoryHistory();

			this.Mapper.SalesTerritoryHistoryMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<SalesTerritoryHistory>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.SalesTerritoryHistoryMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int businessEntityID,
			ApiSalesTerritoryHistoryModel model)
		{
			SalesTerritoryHistory record = await this.GetById(businessEntityID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{businessEntityID}");
			}
			else
			{
				this.Mapper.SalesTerritoryHistoryMapModelToEF(
					businessEntityID,
					model,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int businessEntityID)
		{
			SalesTerritoryHistory record = await this.GetById(businessEntityID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SalesTerritoryHistory>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<POCOSalesTerritoryHistory>> Where(Expression<Func<SalesTerritoryHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSalesTerritoryHistory> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOSalesTerritoryHistory>> SearchLinqPOCO(Expression<Func<SalesTerritoryHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSalesTerritoryHistory> response = new List<POCOSalesTerritoryHistory>();
			List<SalesTerritoryHistory> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.SalesTerritoryHistoryMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<SalesTerritoryHistory>> SearchLinqEF(Expression<Func<SalesTerritoryHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SalesTerritoryHistory.BusinessEntityID)} ASC";
			}
			return await this.Context.Set<SalesTerritoryHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SalesTerritoryHistory>();
		}

		private async Task<List<SalesTerritoryHistory>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SalesTerritoryHistory.BusinessEntityID)} ASC";
			}

			return await this.Context.Set<SalesTerritoryHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SalesTerritoryHistory>();
		}

		private async Task<SalesTerritoryHistory> GetById(int businessEntityID)
		{
			List<SalesTerritoryHistory> records = await this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>607b759e7e2b7e3e9c68790c329f23cc</Hash>
</Codenesium>*/