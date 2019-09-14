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
	public class PostHistoryRepository : AbstractRepository, IPostHistoryRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public PostHistoryRepository(
			ILogger<IPostHistoryRepository> logger,
			ApplicationDbContext context)
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
				                  (x.Comment == null?false : x.Comment.StartsWith(query)) ||
				                  x.CreationDate == query.ToDateTime() ||
				                  (x.PostHistoryTypeIdNavigation == null || x.PostHistoryTypeIdNavigation.RwType == null?false : x.PostHistoryTypeIdNavigation.RwType.StartsWith(query)) ||
				                  (x.PostIdNavigation == null || x.PostIdNavigation.Id == null?false : x.PostIdNavigation.Id == query.ToInt()) ||
				                  (x.RevisionGUID == null?false : x.RevisionGUID.StartsWith(query)) ||
				                  (x.Text == null?false : x.Text.StartsWith(query)) ||
				                  (x.UserDisplayName == null?false : x.UserDisplayName.StartsWith(query)) ||
				                  (x.UserIdNavigation == null || x.UserIdNavigation.DisplayName == null?false : x.UserIdNavigation.DisplayName.StartsWith(query)),
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

		// Foreign key reference to table PostHistoryType via postHistoryTypeId.
		public async virtual Task<PostHistoryType> PostHistoryTypeByPostHistoryTypeId(int postHistoryTypeId)
		{
			return await this.Context.Set<PostHistoryType>()
			       .SingleOrDefaultAsync(x => x.Id == postHistoryTypeId);
		}

		// Foreign key reference to table Post via postId.
		public async virtual Task<Post> PostByPostId(int postId)
		{
			return await this.Context.Set<Post>()
			       .SingleOrDefaultAsync(x => x.Id == postId);
		}

		// Foreign key reference to table User via userId.
		public async virtual Task<User> UserByUserId(int? userId)
		{
			return await this.Context.Set<User>()
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
    <Hash>29085ec2ec060cedbc5404b0731bbc84</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/