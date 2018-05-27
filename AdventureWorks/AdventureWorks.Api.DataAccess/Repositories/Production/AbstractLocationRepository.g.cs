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
		protected IDALLocationMapper Mapper { get; }

		public AbstractLocationRepository(
			IDALLocationMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOLocation>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOLocation> Get(short locationID)
		{
			Location record = await this.GetById(locationID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOLocation> Create(
			DTOLocation dto)
		{
			Location record = new Location();

			this.Mapper.MapDTOToEF(
				default (short),
				dto,
				record);

			this.Context.Set<Location>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			short locationID,
			DTOLocation dto)
		{
			Location record = await this.GetById(locationID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{locationID}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					locationID,
					dto,
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

		public async Task<DTOLocation> GetName(string name)
		{
			var records = await this.SearchLinqDTO(x => x.Name == name);

			return records.FirstOrDefault();
		}

		protected async Task<List<DTOLocation>> Where(Expression<Func<Location, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOLocation> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOLocation>> SearchLinqDTO(Expression<Func<Location, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOLocation> response = new List<DTOLocation>();
			List<Location> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
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
    <Hash>4cea7e7a904c1c82bccf8a2e5bd21010</Hash>
</Codenesium>*/