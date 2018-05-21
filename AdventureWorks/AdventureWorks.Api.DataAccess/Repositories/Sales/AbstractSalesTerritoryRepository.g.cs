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
	public abstract class AbstractSalesTerritoryRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractSalesTerritoryRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOSalesTerritory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOSalesTerritory> Get(int territoryID)
		{
			SalesTerritory record = await this.GetById(territoryID);

			return this.Mapper.SalesTerritoryMapEFToPOCO(record);
		}

		public async virtual Task<POCOSalesTerritory> Create(
			ApiSalesTerritoryModel model)
		{
			SalesTerritory record = new SalesTerritory();

			this.Mapper.SalesTerritoryMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<SalesTerritory>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.SalesTerritoryMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int territoryID,
			ApiSalesTerritoryModel model)
		{
			SalesTerritory record = await this.GetById(territoryID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{territoryID}");
			}
			else
			{
				this.Mapper.SalesTerritoryMapModelToEF(
					territoryID,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int territoryID)
		{
			SalesTerritory record = await this.GetById(territoryID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SalesTerritory>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<POCOSalesTerritory> GetName(string name)
		{
			var records = await this.SearchLinqPOCO(x => x.Name == name);

			return records.FirstOrDefault();
		}

		protected async Task<List<POCOSalesTerritory>> Where(Expression<Func<SalesTerritory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSalesTerritory> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOSalesTerritory>> SearchLinqPOCO(Expression<Func<SalesTerritory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSalesTerritory> response = new List<POCOSalesTerritory>();
			List<SalesTerritory> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.SalesTerritoryMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<SalesTerritory>> SearchLinqEF(Expression<Func<SalesTerritory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SalesTerritory.TerritoryID)} ASC";
			}
			return await this.Context.Set<SalesTerritory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SalesTerritory>();
		}

		private async Task<List<SalesTerritory>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SalesTerritory.TerritoryID)} ASC";
			}

			return await this.Context.Set<SalesTerritory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SalesTerritory>();
		}

		private async Task<SalesTerritory> GetById(int territoryID)
		{
			List<SalesTerritory> records = await this.SearchLinqEF(x => x.TerritoryID == territoryID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>e44c67b0344a717015d36e486e745fce</Hash>
</Codenesium>*/