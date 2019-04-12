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

namespace TicketingCRMNS.Api.DataAccess
{
	public abstract class AbstractProvinceRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractProvinceRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Province>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  (x.CountryIdNavigation == null || x.CountryIdNavigation.Name == null?false : x.CountryIdNavigation.Name.StartsWith(query)) ||
				                  x.Name.StartsWith(query),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Province> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Province> Create(Province item)
		{
			this.Context.Set<Province>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Province item)
		{
			var entity = this.Context.Set<Province>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Province>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int id)
		{
			Province record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Province>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Non-unique constraint IX_province_countryId.
		public async virtual Task<List<Province>> ByCountryId(int countryId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.CountryId == countryId, limit, offset);
		}

		// Foreign key reference to this table City via provinceId.
		public async virtual Task<List<City>> CitiesByProvinceId(int provinceId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<City>()
			       .Include(x => x.ProvinceIdNavigation)

			       .Where(x => x.ProvinceId == provinceId).AsQueryable().Skip(offset).Take(limit).ToListAsync<City>();
		}

		// Foreign key reference to this table Venue via provinceId.
		public async virtual Task<List<Venue>> VenuesByProvinceId(int provinceId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Venue>()
			       .Include(x => x.AdminIdNavigation)
			       .Include(x => x.ProvinceIdNavigation)

			       .Where(x => x.ProvinceId == provinceId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Venue>();
		}

		// Foreign key reference to table Country via countryId.
		public async virtual Task<Country> CountryByCountryId(int countryId)
		{
			return await this.Context.Set<Country>()
			       .SingleOrDefaultAsync(x => x.Id == countryId);
		}

		protected async Task<List<Province>> Where(
			Expression<Func<Province, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Province, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Province>()
			       .Include(x => x.CountryIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Province>();
		}

		private async Task<Province> GetById(int id)
		{
			List<Province> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>781318251c29b650397bdd19739ba43b</Hash>
</Codenesium>*/