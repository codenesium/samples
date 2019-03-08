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
	public abstract class AbstractVotesRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractVotesRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Votes>> All(int limit = int.MaxValue, int offset = 0, string query = "")
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
				                  x.Id == query.ToInt() ||
				                  x.PostId == query.ToInt() ||
				                  x.UserId == query.ToNullableInt() ||
				                  x.VoteTypeId == query.ToInt(),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Votes> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Votes> Create(Votes item)
		{
			this.Context.Set<Votes>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Votes item)
		{
			var entity = this.Context.Set<Votes>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Votes>().Attach(item);
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
			Votes record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Votes>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Non-unique constraint NonClusteredIndex-20180824-125907.
		public async virtual Task<List<Votes>> ByUserId(int? userId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.UserId == userId, limit, offset);
		}

		// Non-unique constraint IX_Votes_PostId.
		public async virtual Task<List<Votes>> ByPostId(int postId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.PostId == postId, limit, offset);
		}

		// Non-unique constraint IX_Votes_VoteTypeId.
		public async virtual Task<List<Votes>> ByVoteTypeId(int voteTypeId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.VoteTypeId == voteTypeId, limit, offset);
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

		// Foreign key reference to table VoteTypes via voteTypeId.
		public async virtual Task<VoteTypes> VoteTypesByVoteTypeId(int voteTypeId)
		{
			return await this.Context.Set<VoteTypes>()
			       .SingleOrDefaultAsync(x => x.Id == voteTypeId);
		}

		protected async Task<List<Votes>> Where(
			Expression<Func<Votes, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Votes, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Votes>()
			       .Include(x => x.PostIdNavigation)
			       .Include(x => x.UserIdNavigation)
			       .Include(x => x.VoteTypeIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Votes>();
		}

		private async Task<Votes> GetById(int id)
		{
			List<Votes> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>3fd1b9f1b5cbd0c9565db17d4df8bd1c</Hash>
</Codenesium>*/