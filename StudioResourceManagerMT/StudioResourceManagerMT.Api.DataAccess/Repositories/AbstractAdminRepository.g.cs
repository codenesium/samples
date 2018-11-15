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

namespace StudioResourceManagerMTNS.Api.DataAccess
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

		public virtual Task<List<Admin>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
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

		public async virtual Task<List<Admin>> ByUserId(int userId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.UserId == userId, limit, offset);
		}

		public async virtual Task<User> UserByUserId(int userId)
		{
			return await this.Context.Set<User>().SingleOrDefaultAsync(x => x.Id == userId);
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

			return await this.Context.Set<Admin>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Admin>();
		}

		private async Task<Admin> GetById(int id)
		{
			List<Admin> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>f3e09cd282e84e797bb75b47eac11d33</Hash>
</Codenesium>*/