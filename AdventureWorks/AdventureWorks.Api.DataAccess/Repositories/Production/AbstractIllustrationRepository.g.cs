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

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractIllustrationRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractIllustrationRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Illustration>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.Diagram.StartsWith(query) ||
				                  x.IllustrationID == query.ToInt() ||
				                  x.ModifiedDate == query.ToDateTime(),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Illustration> Get(int illustrationID)
		{
			return await this.GetById(illustrationID);
		}

		public async virtual Task<Illustration> Create(Illustration item)
		{
			this.Context.Set<Illustration>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Illustration item)
		{
			var entity = this.Context.Set<Illustration>().Local.FirstOrDefault(x => x.IllustrationID == item.IllustrationID);
			if (entity == null)
			{
				this.Context.Set<Illustration>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int illustrationID)
		{
			Illustration record = await this.GetById(illustrationID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Illustration>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<Illustration>> Where(
			Expression<Func<Illustration, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Illustration, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.IllustrationID;
			}

			return await this.Context.Set<Illustration>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Illustration>();
		}

		private async Task<Illustration> GetById(int illustrationID)
		{
			List<Illustration> records = await this.Where(x => x.IllustrationID == illustrationID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>6a6c7ee135062fefb3a3013b709e7702</Hash>
</Codenesium>*/