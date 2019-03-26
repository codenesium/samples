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
	public abstract class AbstractMessageRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractMessageRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Message>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.Content.StartsWith(query) ||
				                  x.MessageId == query.ToInt() ||
				                  x.SenderUserId == query.ToNullableInt(),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Message> Get(int messageId)
		{
			return await this.GetById(messageId);
		}

		public async virtual Task<Message> Create(Message item)
		{
			this.Context.Set<Message>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Message item)
		{
			var entity = this.Context.Set<Message>().Local.FirstOrDefault(x => x.MessageId == item.MessageId);
			if (entity == null)
			{
				this.Context.Set<Message>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int messageId)
		{
			Message record = await this.GetById(messageId);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Message>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Non-unique constraint IX_Message_sender_user_id.
		public async virtual Task<List<Message>> BySenderUserId(int? senderUserId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.SenderUserId == senderUserId, limit, offset);
		}

		// Foreign key reference to this table Messenger via messageId.
		public async virtual Task<List<Messenger>> MessengersByMessageId(int messageId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Messenger>()
			       .Include(x => x.MessageIdNavigation)
			       .Include(x => x.ToUserIdNavigation)
			       .Include(x => x.UserIdNavigation)

			       .Where(x => x.MessageId == messageId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Messenger>();
		}

		// Foreign key reference to table User via senderUserId.
		public async virtual Task<User> UserBySenderUserId(int? senderUserId)
		{
			return await this.Context.Set<User>()
			       .SingleOrDefaultAsync(x => x.UserId == senderUserId);
		}

		protected async Task<List<Message>> Where(
			Expression<Func<Message, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Message, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.MessageId;
			}

			return await this.Context.Set<Message>()
			       .Include(x => x.SenderUserIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Message>();
		}

		private async Task<Message> GetById(int messageId)
		{
			List<Message> records = await this.Where(x => x.MessageId == messageId);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>7c08f27a86c6a3687a6f16bb252c1b8d</Hash>
</Codenesium>*/