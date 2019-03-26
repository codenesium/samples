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
	public abstract class AbstractVoteTypesRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractVoteTypesRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<VoteTypes>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.Id == query.ToInt() ||
				                  x.Name.StartsWith(query),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<VoteTypes> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<VoteTypes> Create(VoteTypes item)
		{
			this.Context.Set<VoteTypes>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(VoteTypes item)
		{
			var entity = this.Context.Set<VoteTypes>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<VoteTypes>().Attach(item);
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
			VoteTypes record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<VoteTypes>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to this table Votes via voteTypeId.
		public async virtual Task<List<Votes>> VotesByVoteTypeId(int voteTypeId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Votes>()
			       .Include(x => x.PostIdNavigation)
			       .Include(x => x.UserIdNavigation)
			       .Include(x => x.VoteTypeIdNavigation)

			       .Where(x => x.VoteTypeId == voteTypeId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Votes>();
		}

		protected async Task<List<VoteTypes>> Where(
			Expression<Func<VoteTypes, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<VoteTypes, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<VoteTypes>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<VoteTypes>();
		}

		private async Task<VoteTypes> GetById(int id)
		{
			List<VoteTypes> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>28ab2207c3a178a21ecaa4fb14f5751d</Hash>
</Codenesium>*/