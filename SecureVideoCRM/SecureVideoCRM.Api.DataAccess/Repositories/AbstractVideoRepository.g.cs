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

namespace SecureVideoCRMNS.Api.DataAccess
{
	public abstract class AbstractVideoRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractVideoRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Video>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.Description.StartsWith(query) ||
				                  x.Title.StartsWith(query) ||
				                  x.Url.StartsWith(query),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Video> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Video> Create(Video item)
		{
			this.Context.Set<Video>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Video item)
		{
			var entity = this.Context.Set<Video>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Video>().Attach(item);
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
			Video record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Video>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<Video>> Where(
			Expression<Func<Video, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Video, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Video>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Video>();
		}

		private async Task<Video> GetById(int id)
		{
			List<Video> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>c6cfa4567027e9f9b972ddfd30c45492</Hash>
</Codenesium>*/