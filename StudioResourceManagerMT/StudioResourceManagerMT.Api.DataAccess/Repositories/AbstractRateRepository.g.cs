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

namespace StudioResourceManagerMTNS.Api.DataAccess
{
	public abstract class AbstractRateRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractRateRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Rate>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.AmountPerMinute.ToDecimal() == query.ToDecimal() ||
				                  x.Id == query.ToInt() ||
				                  x.TeacherId == query.ToInt() ||
				                  x.TeacherSkillId == query.ToInt(),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Rate> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Rate> Create(Rate item)
		{
			this.Context.Set<Rate>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Rate item)
		{
			var entity = this.Context.Set<Rate>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Rate>().Attach(item);
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
			Rate record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Rate>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<Rate>> Where(
			Expression<Func<Rate, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Rate, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Rate>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Rate>();
		}

		private async Task<Rate> GetById(int id)
		{
			List<Rate> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>c4828d3bea012c6f8f836949f8d78d8b</Hash>
</Codenesium>*/