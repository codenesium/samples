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

namespace StackOverflowNS.Api.DataAccess
{
	public abstract class AbstractBadgeRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractBadgeRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Badge>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.Date == query.ToDateTime() ||
				                  x.Id == query.ToInt() ||
				                  x.Name.StartsWith(query) ||
				                  x.UserId == query.ToInt(),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Badge> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Badge> Create(Badge item)
		{
			this.Context.Set<Badge>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Badge item)
		{
			var entity = this.Context.Set<Badge>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Badge>().Attach(item);
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
			Badge record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Badge>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<Badge>> Where(
			Expression<Func<Badge, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Badge, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Badge>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Badge>();
		}

		private async Task<Badge> GetById(int id)
		{
			List<Badge> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>5db4c14bbde386da306b093a97e313c8</Hash>
</Codenesium>*/