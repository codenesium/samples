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

		public virtual Task<List<Venue>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.Address1.StartsWith(query) ||
				                  x.Address2.StartsWith(query) ||
				                  x.AdminId == query.ToInt() ||
				                  x.Email.StartsWith(query) ||
				                  x.Facebook.StartsWith(query) ||
				                  x.Name.StartsWith(query) ||
				                  x.Phone.StartsWith(query) ||
				                  x.ProvinceId == query.ToInt() ||
				                  x.Website.StartsWith(query),
				                  limit,
				                  offset);
			}
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

		// Non-unique constraint IX_venue_adminId.
		public async virtual Task<List<Venue>> ByAdminId(int adminId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.AdminId == adminId, limit, offset);
		}

		// Non-unique constraint IX_venue_provinceId.
		public async virtual Task<List<Venue>> ByProvinceId(int provinceId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.ProvinceId == provinceId, limit, offset);
		}

		// Foreign key reference to table Admin via adminId.
		public async virtual Task<Admin> AdminByAdminId(int adminId)
		{
			return await this.Context.Set<Admin>()
			       .SingleOrDefaultAsync(x => x.Id == adminId);
		}

		// Foreign key reference to table Province via provinceId.
		public async virtual Task<Province> ProvinceByProvinceId(int provinceId)
		{
			return await this.Context.Set<Province>()
			       .SingleOrDefaultAsync(x => x.Id == provinceId);
		}

		protected async Task<List<Venue>> Where(
			Expression<Func<Venue, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Venue, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Venue>()
			       .Include(x => x.AdminIdNavigation)
			       .Include(x => x.ProvinceIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Venue>();
		}

		private async Task<Venue> GetById(int id)
		{
			List<Venue> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>0c41aedf3cae995faf5a3fe63c875e2d</Hash>
</Codenesium>*/