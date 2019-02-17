using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractCountryRegionRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractCountryRegionRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<CountryRegion>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.CountryRegionCode.StartsWith(query) ||
				                  x.ModifiedDate == query.ToDateTime() ||
				                  x.Name.StartsWith(query),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<CountryRegion> Get(string countryRegionCode)
		{
			return await this.GetById(countryRegionCode);
		}

		public async virtual Task<CountryRegion> Create(CountryRegion item)
		{
			this.Context.Set<CountryRegion>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(CountryRegion item)
		{
			var entity = this.Context.Set<CountryRegion>().Local.FirstOrDefault(x => x.CountryRegionCode == item.CountryRegionCode);
			if (entity == null)
			{
				this.Context.Set<CountryRegion>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			string countryRegionCode)
		{
			CountryRegion record = await this.GetById(countryRegionCode);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<CountryRegion>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// unique constraint AK_CountryRegion_Name.
		public async virtual Task<CountryRegion> ByName(string name)
		{
			return await this.Context.Set<CountryRegion>()

			       .FirstOrDefaultAsync(x => x.Name == name);
		}

		// Foreign key reference to this table StateProvince via countryRegionCode.
		public async virtual Task<List<StateProvince>> StateProvincesByCountryRegionCode(string countryRegionCode, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<StateProvince>()
			       .Where(x => x.CountryRegionCode == countryRegionCode).AsQueryable().Skip(offset).Take(limit).ToListAsync<StateProvince>();
		}

		protected async Task<List<CountryRegion>> Where(
			Expression<Func<CountryRegion, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<CountryRegion, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.CountryRegionCode;
			}

			return await this.Context.Set<CountryRegion>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<CountryRegion>();
		}

		private async Task<CountryRegion> GetById(string countryRegionCode)
		{
			List<CountryRegion> records = await this.Where(x => x.CountryRegionCode == countryRegionCode);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>1d8fabf90add04791399f1ba95f4eb4a</Hash>
</Codenesium>*/