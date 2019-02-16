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
	public abstract class AbstractCommentRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractCommentRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Comment>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.CreationDate == query.ToDateTime() ||
				                  x.Id == query.ToInt() ||
				                  x.PostId == query.ToInt() ||
				                  x.Score == query.ToNullableInt() ||
				                  x.Text.StartsWith(query) ||
				                  x.UserId == query.ToNullableInt(),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Comment> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Comment> Create(Comment item)
		{
			this.Context.Set<Comment>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Comment item)
		{
			var entity = this.Context.Set<Comment>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Comment>().Attach(item);
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
			Comment record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Comment>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<Comment>> Where(
			Expression<Func<Comment, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Comment, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Comment>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Comment>();
		}

		private async Task<Comment> GetById(int id)
		{
			List<Comment> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>9ad7eadf6440c7d57779e60925c764e0</Hash>
</Codenesium>*/