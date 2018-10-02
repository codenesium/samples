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
	public abstract class AbstractReplyRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractReplyRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Reply>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<Reply> Get(int replyId)
		{
			return await this.GetById(replyId);
		}

		public async virtual Task<Reply> Create(Reply item)
		{
			this.Context.Set<Reply>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Reply item)
		{
			var entity = this.Context.Set<Reply>().Local.FirstOrDefault(x => x.ReplyId == item.ReplyId);
			if (entity == null)
			{
				this.Context.Set<Reply>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int replyId)
		{
			Reply record = await this.GetById(replyId);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Reply>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<List<Reply>> ByReplierUserId(int replierUserId, int limit = int.MaxValue, int offset = 0)
		{
			var records = await this.Where(x => x.ReplierUserId == replierUserId, limit, offset);

			return records;
		}

		public async virtual Task<User> GetUser(int replierUserId)
		{
			return await this.Context.Set<User>().SingleOrDefaultAsync(x => x.UserId == replierUserId);
		}

		protected async Task<List<Reply>> Where(
			Expression<Func<Reply, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Reply, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.ReplyId;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<Reply>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Reply>();
			}
			else
			{
				return await this.Context.Set<Reply>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Reply>();
			}
		}

		private async Task<Reply> GetById(int replyId)
		{
			List<Reply> records = await this.Where(x => x.ReplyId == replyId);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>80d060d739dd519a6c9f0aa42c670e6d</Hash>
</Codenesium>*/