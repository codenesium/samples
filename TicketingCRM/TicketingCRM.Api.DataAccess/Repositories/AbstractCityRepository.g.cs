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
	public abstract class AbstractCityRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractCityRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<City>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.Name.StartsWith(query) ||
				                  x.ProvinceId == query.ToInt(),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<City> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<City> Create(City item)
		{
			this.Context.Set<City>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(City item)
		{
			var entity = this.Context.Set<City>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<City>().Attach(item);
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
			City record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<City>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Non-unique constraint IX_city_provinceId.
		public async virtual Task<List<City>> ByProvinceId(int provinceId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.ProvinceId == provinceId, limit, offset);
		}

		// Foreign key reference to this table Event via cityId.
		public async virtual Task<List<Event>> EventsByCityId(int cityId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Event>()
			       .Include(x => x.CityIdNavigation)

			       .Where(x => x.CityId == cityId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Event>();
		}

		// Foreign key reference to table Province via provinceId.
		public async virtual Task<Province> ProvinceByProvinceId(int provinceId)
		{
			return await this.Context.Set<Province>()
			       .SingleOrDefaultAsync(x => x.Id == provinceId);
		}

		protected async Task<List<City>> Where(
			Expression<Func<City, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<City, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<City>()
			       .Include(x => x.ProvinceIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<City>();
		}

		private async Task<City> GetById(int id)
		{
			List<City> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>a0fc29b282cb401d62096ab33bed7130</Hash>
</Codenesium>*/