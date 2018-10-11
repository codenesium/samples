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
	public abstract class AbstractVoteRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractVoteRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Vote>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
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

		public async Task<List<Vote>> ByUserId(int? userId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.UserId == userId, limit, offset);
		}

		protected async Task<List<Vote>> Where(
			Expression<Func<Vote, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Vote, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<Vote>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Vote>();
			}
			else
			{
				return await this.Context.Set<Vote>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Vote>();
			}
		}

		private async Task<Vote> GetById(int id)
		{
			List<Vote> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>bfd4350e9c27c155296a0fd441b8d32e</Hash>
</Codenesium>*/