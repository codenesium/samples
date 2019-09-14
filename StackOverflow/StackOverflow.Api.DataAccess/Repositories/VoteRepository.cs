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
	public class VoteRepository : AbstractRepository, IVoteRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public VoteRepository(
			ILogger<IVoteRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Vote>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.BountyAmount == query.ToNullableInt() ||
				                  x.CreationDate == query.ToDateTime() ||
				                  (x.PostIdNavigation == null || x.PostIdNavigation.Id == null?false : x.PostIdNavigation.Id == query.ToInt()) ||
				                  (x.UserIdNavigation == null || x.UserIdNavigation.DisplayName == null?false : x.UserIdNavigation.DisplayName.StartsWith(query)) ||
				                  (x.VoteTypeIdNavigation == null || x.VoteTypeIdNavigation.Name == null?false : x.VoteTypeIdNavigation.Name.StartsWith(query)),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Vote> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Vote> Create(Vote item)
		{
			this.Context.Set<Vote>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Vote item)
		{
			var entity = this.Context.Set<Vote>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Vote>().Attach(item);
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
			Vote record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Vote>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Non-unique constraint NonClusteredIndex-20180824-125907.
		public async virtual Task<List<Vote>> ByUserId(int? userId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.UserId == userId, limit, offset);
		}

		// Non-unique constraint IX_Votes_PostId.
		public async virtual Task<List<Vote>> ByPostId(int postId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.PostId == postId, limit, offset);
		}

		// Non-unique constraint IX_Votes_VoteTypeId.
		public async virtual Task<List<Vote>> ByVoteTypeId(int voteTypeId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.VoteTypeId == voteTypeId, limit, offset);
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

		// Foreign key reference to table VoteType via voteTypeId.
		public async virtual Task<VoteType> VoteTypeByVoteTypeId(int voteTypeId)
		{
			return await this.Context.Set<VoteType>()
			       .SingleOrDefaultAsync(x => x.Id == voteTypeId);
		}

		protected async Task<List<Vote>> Where(
			Expression<Func<Vote, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Vote, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Vote>()
			       .Include(x => x.PostIdNavigation)
			       .Include(x => x.UserIdNavigation)
			       .Include(x => x.VoteTypeIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Vote>();
		}

		private async Task<Vote> GetById(int id)
		{
			List<Vote> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>d3521d5a356954d2cbb4d0bcced052a3</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/