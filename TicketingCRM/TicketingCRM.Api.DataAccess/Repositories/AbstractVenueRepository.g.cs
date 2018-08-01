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
	public abstract class AbstractVenueRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractVenueRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Venue>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<Venue> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Venue> Create(Venue item)
		{
			this.Context.Set<Venue>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Venue item)
		{
			var entity = this.Context.Set<Venue>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Venue>().Attach(item);
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
			Venue record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Venue>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<List<Venue>> ByAdminId(int adminId)
		{
			var records = await this.Where(x => x.AdminId == adminId);

			return records;
		}

		public async Task<List<Venue>> ByProvinceId(int provinceId)
		{
			var records = await this.Where(x => x.ProvinceId == provinceId);

			return records;
		}

		public async virtual Task<Admin> GetAdmin(int adminId)
		{
			return await this.Context.Set<Admin>().SingleOrDefaultAsync(x => x.Id == adminId);
		}

		public async virtual Task<Province> GetProvince(int provinceId)
		{
			return await this.Context.Set<Province>().SingleOrDefaultAsync(x => x.Id == provinceId);
		}

		protected async Task<List<Venue>> Where(
			Expression<Func<Venue, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Venue, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<Venue>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Venue>();
			}
			else
			{
				return await this.Context.Set<Venue>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Venue>();
			}
		}

		private async Task<Venue> GetById(int id)
		{
			List<Venue> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>6d8d16c757d487f62b3763b5743d3b8f</Hash>
</Codenesium>*/