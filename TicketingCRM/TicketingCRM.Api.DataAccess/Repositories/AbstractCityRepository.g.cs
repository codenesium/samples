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

		public virtual Task<List<City>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
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

		public async Task<List<City>> ByProvinceId(int provinceId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.ProvinceId == provinceId, limit, offset);
		}

		public async virtual Task<List<Event>> EventsByCityId(int cityId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Event>().Where(x => x.CityId == cityId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Event>();
		}

		public async virtual Task<Province> ProvinceByProvinceId(int provinceId)
		{
			return await this.Context.Set<Province>().SingleOrDefaultAsync(x => x.Id == provinceId);
		}

		protected async Task<List<City>> Where(
			Expression<Func<City, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<City, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<City>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<City>();
			}
			else
			{
				return await this.Context.Set<City>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<City>();
			}
		}

		private async Task<City> GetById(int id)
		{
			List<City> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>312c2f71fdf3c5daa206f54c186cca8c</Hash>
</Codenesium>*/