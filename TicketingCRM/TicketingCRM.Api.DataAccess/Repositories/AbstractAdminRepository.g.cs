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
	public abstract class AbstractAdminRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractAdminRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Admin>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.Email.StartsWith(query) ||
				                  x.FirstName.StartsWith(query) ||
				                  x.Id == query.ToInt() ||
				                  x.LastName.StartsWith(query) ||
				                  x.Password.StartsWith(query) ||
				                  x.Phone.StartsWith(query) ||
				                  x.Username.StartsWith(query),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Admin> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Admin> Create(Admin item)
		{
			this.Context.Set<Admin>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Admin item)
		{
			var entity = this.Context.Set<Admin>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Admin>().Attach(item);
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
			Admin record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Admin>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to this table Venue via adminId.
		public async virtual Task<List<Venue>> VenuesByAdminId(int adminId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Venue>()
			       .Include(x => x.AdminIdNavigation)
			       .Include(x => x.ProvinceIdNavigation)

			       .Where(x => x.AdminId == adminId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Venue>();
		}

		protected async Task<List<Admin>> Where(
			Expression<Func<Admin, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Admin, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Admin>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Admin>();
		}

		private async Task<Admin> GetById(int id)
		{
			List<Admin> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>b0706002e82bd219e30e3bcb00acd88a</Hash>
</Codenesium>*/