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
		protected IDALSalesTerritoryMapper Mapper { get; }

		public AbstractSalesTerritoryRepository(
			IDALSalesTerritoryMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOSalesTerritory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOSalesTerritory> Get(int territoryID)
		{
			SalesTerritory record = await this.GetById(territoryID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOSalesTerritory> Create(
			DTOSalesTerritory dto)
		{
			SalesTerritory record = new SalesTerritory();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<SalesTerritory>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int territoryID,
			DTOSalesTerritory dto)
		{
			SalesTerritory record = await this.GetById(territoryID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{territoryID}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					territoryID,
					dto,
					record);

				await this.Context.SaveChangesAsync();
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

		public async Task<DTOSalesTerritory> GetName(string name)
		{
			var records = await this.SearchLinqDTO(x => x.Name == name);

			return records.FirstOrDefault();
		}

		protected async Task<List<DTOSalesTerritory>> Where(Expression<Func<SalesTerritory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOSalesTerritory> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOSalesTerritory>> SearchLinqDTO(Expression<Func<SalesTerritory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOSalesTerritory> response = new List<DTOSalesTerritory>();
			List<SalesTerritory> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
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
    <Hash>f3ce3b3033ca606df5fad1c113ba6692</Hash>
</Codenesium>*/