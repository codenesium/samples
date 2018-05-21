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
	public abstract class AbstractLocationRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractLocationRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOLocation>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOLocation> Get(short locationID)
		{
			Location record = await this.GetById(locationID);

			return this.Mapper.LocationMapEFToPOCO(record);
		}

		public async virtual Task<POCOLocation> Create(
			ApiLocationModel model)
		{
			Location record = new Location();

			this.Mapper.LocationMapModelToEF(
				default (short),
				model,
				record);

			this.Context.Set<Location>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.LocationMapEFToPOCO(record);
		}

		public async virtual Task Update(
			short locationID,
			ApiLocationModel model)
		{
			Location record = await this.GetById(locationID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{locationID}");
			}
			else
			{
				this.Mapper.LocationMapModelToEF(
					locationID,
					model,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			short locationID)
		{
			Location record = await this.GetById(locationID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Location>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<POCOLocation> GetName(string name)
		{
			var records = await this.SearchLinqPOCO(x => x.Name == name);

			return records.FirstOrDefault();
		}

		protected async Task<List<POCOLocation>> Where(Expression<Func<Location, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOLocation> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOLocation>> SearchLinqPOCO(Expression<Func<Location, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOLocation> response = new List<POCOLocation>();
			List<Location> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.LocationMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<Location>> SearchLinqEF(Expression<Func<Location, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Location.LocationID)} ASC";
			}
			return await this.Context.Set<Location>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Location>();
		}

		private async Task<List<Location>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Location.LocationID)} ASC";
			}

			return await this.Context.Set<Location>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Location>();
		}

		private async Task<Location> GetById(short locationID)
		{
			List<Location> records = await this.SearchLinqEF(x => x.LocationID == locationID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>4b6ae6ceb5d2e396f8d7376cd072ad18</Hash>
</Codenesium>*/