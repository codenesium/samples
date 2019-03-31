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
	public abstract class AbstractMessengerRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractMessengerRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Messenger>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.Date == query.ToNullableDateTime() ||
				                  x.FromUserId == query.ToNullableInt() ||
				                  x.MessageId == query.ToNullableInt() ||
				                  x.Time == query.ToNullableTimespan() ||
				                  x.ToUserId == query.ToInt() ||
				                  x.UserId == query.ToNullableInt(),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Messenger> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Messenger> Create(Messenger item)
		{
			this.Context.Set<Messenger>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Messenger item)
		{
			var entity = this.Context.Set<Messenger>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Messenger>().Attach(item);
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
			Messenger record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Messenger>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Non-unique constraint IX_Messenger_message_id.
		public async virtual Task<List<Messenger>> ByMessageId(int? messageId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.MessageId == messageId, limit, offset);
		}

		// Non-unique constraint IX_Messenger_to_user_id.
		public async virtual Task<List<Messenger>> ByToUserId(int toUserId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.ToUserId == toUserId, limit, offset);
		}

		// Non-unique constraint IX_Messenger_user_id.
		public async virtual Task<List<Messenger>> ByUserId(int? userId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.UserId == userId, limit, offset);
		}

		// Foreign key reference to table Message via messageId.
		public async virtual Task<Message> MessageByMessageId(int? messageId)
		{
			return await this.Context.Set<Message>()
			       .SingleOrDefaultAsync(x => x.MessageId == messageId);
		}

		// Foreign key reference to table User via toUserId.
		public async virtual Task<User> UserByToUserId(int toUserId)
		{
			return await this.Context.Set<User>()
			       .SingleOrDefaultAsync(x => x.UserId == toUserId);
		}

		// Foreign key reference to table User via userId.
		public async virtual Task<User> UserByUserId(int? userId)
		{
			return await this.Context.Set<User>()
			       .SingleOrDefaultAsync(x => x.UserId == userId);
		}

		protected async Task<List<Messenger>> Where(
			Expression<Func<Messenger, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Messenger, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Messenger>()
			       .Include(x => x.MessageIdNavigation)
			       .Include(x => x.ToUserIdNavigation)
			       .Include(x => x.UserIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Messenger>();
		}

		private async Task<Messenger> GetById(int id)
		{
			List<Messenger> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>113cce3146cad5b39fe118a5bd6d6e39</Hash>
</Codenesium>*/