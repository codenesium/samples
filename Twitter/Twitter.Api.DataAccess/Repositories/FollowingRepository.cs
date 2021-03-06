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

namespace TwitterNS.Api.DataAccess
{
	public class FollowingRepository : AbstractRepository, IFollowingRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public FollowingRepository(
			ILogger<IFollowingRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Following>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.DateFollowed == query.ToNullableDateTime() ||
				                  (x.Muted == null?false : x.Muted.StartsWith(query)),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Following> Get(int userId)
		{
			return await this.GetById(userId);
		}

		public async virtual Task<Following> Create(Following item)
		{
			this.Context.Set<Following>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Following item)
		{
			var entity = this.Context.Set<Following>().Local.FirstOrDefault(x => x.UserId == item.UserId);
			if (entity == null)
			{
				this.Context.Set<Following>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int userId)
		{
			Following record = await this.GetById(userId);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Following>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<Following>> Where(
			Expression<Func<Following, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Following, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.UserId;
			}

			return await this.Context.Set<Following>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Following>();
		}

		private async Task<Following> GetById(int userId)
		{
			List<Following> records = await this.Where(x => x.UserId == userId);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>1dd5e99f3c0bb8f9d2eea043d5eb7bb6</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/