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

namespace StudioResourceManagerNS.Api.DataAccess
{
	public class AdminRepository : AbstractRepository, IAdminRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AdminRepository(
			ILogger<IAdminRepository> logger,
			ApplicationDbContext context)
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
				                  x.Birthday == query.ToNullableDateTime() ||
				                  (x.Email == null?false : x.Email.StartsWith(query)) ||
				                  (x.FirstName == null?false : x.FirstName.StartsWith(query)) ||
				                  (x.LastName == null?false : x.LastName.StartsWith(query)) ||
				                  (x.Phone == null?false : x.Phone.StartsWith(query)) ||
				                  (x.UserIdNavigation == null || x.UserIdNavigation.Username == null?false : x.UserIdNavigation.Username.StartsWith(query)),
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

		// Non-unique constraint IX_Admin_userId.
		public async virtual Task<List<Admin>> ByUserId(int userId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.UserId == userId, limit, offset);
		}

		// Foreign key reference to table User via userId.
		public async virtual Task<User> UserByUserId(int userId)
		{
			return await this.Context.Set<User>()
			       .SingleOrDefaultAsync(x => x.Id == userId);
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
			       .Include(x => x.UserIdNavigation)

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
    <Hash>906a10f8c0d8c824091c57eb30b66982</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/