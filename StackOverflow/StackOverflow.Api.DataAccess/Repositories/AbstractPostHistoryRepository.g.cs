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
	public abstract class AbstractPostHistoryRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractPostHistoryRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<PostHistory>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.Comment.StartsWith(query) ||
				                  x.CreationDate == query.ToDateTime() ||
				                  x.Id == query.ToInt() ||
				                  x.PostHistoryTypeId == query.ToInt() ||
				                  x.PostId == query.ToInt() ||
				                  x.RevisionGUID.StartsWith(query) ||
				                  x.Text.StartsWith(query) ||
				                  x.UserDisplayName.StartsWith(query) ||
				                  x.UserId == query.ToNullableInt(),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<PostHistory> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<PostHistory> Create(PostHistory item)
		{
			this.Context.Set<PostHistory>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(PostHistory item)
		{
			var entity = this.Context.Set<PostHistory>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<PostHistory>().Attach(item);
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
			PostHistory record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<PostHistory>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Non-unique constraint IX_PostHistory_PostHistoryTypeId.
		public async virtual Task<List<PostHistory>> ByPostHistoryTypeId(int postHistoryTypeId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.PostHistoryTypeId == postHistoryTypeId, limit, offset);
		}

		// Non-unique constraint IX_PostHistory_PostId.
		public async virtual Task<List<PostHistory>> ByPostId(int postId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.PostId == postId, limit, offset);
		}

		// Non-unique constraint IX_PostHistory_UserId.
		public async virtual Task<List<PostHistory>> ByUserId(int? userId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.UserId == userId, limit, offset);
		}

		// Foreign key reference to table PostHistoryTypes via postHistoryTypeId.
		public async virtual Task<PostHistoryTypes> PostHistoryTypesByPostHistoryTypeId(int postHistoryTypeId)
		{
			return await this.Context.Set<PostHistoryTypes>()
			       .SingleOrDefaultAsync(x => x.Id == postHistoryTypeId);
		}

		// Foreign key reference to table Posts via postId.
		public async virtual Task<Posts> PostsByPostId(int postId)
		{
			return await this.Context.Set<Posts>()
			       .SingleOrDefaultAsync(x => x.Id == postId);
		}

		// Foreign key reference to table Users via userId.
		public async virtual Task<Users> UsersByUserId(int? userId)
		{
			return await this.Context.Set<Users>()
			       .SingleOrDefaultAsync(x => x.Id == userId);
		}

		protected async Task<List<PostHistory>> Where(
			Expression<Func<PostHistory, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<PostHistory, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<PostHistory>()
			       .Include(x => x.PostHistoryTypeIdNavigation)
			       .Include(x => x.PostIdNavigation)
			       .Include(x => x.UserIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<PostHistory>();
		}

		private async Task<PostHistory> GetById(int id)
		{
			List<PostHistory> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>6abab1a0f31032bb98d0240dd051bb00</Hash>
</Codenesium>*/