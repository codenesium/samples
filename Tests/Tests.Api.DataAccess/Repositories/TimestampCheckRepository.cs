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

namespace TestsNS.Api.DataAccess
{
	public class TimestampCheckRepository : AbstractRepository, ITimestampCheckRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public TimestampCheckRepository(
			ILogger<ITimestampCheckRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<TimestampCheck>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  (x.Name == null?false : x.Name.StartsWith(query)),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<TimestampCheck> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<TimestampCheck> Create(TimestampCheck item)
		{
			this.Context.Set<TimestampCheck>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(TimestampCheck item)
		{
			var entity = this.Context.Set<TimestampCheck>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<TimestampCheck>().Attach(item);
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
			TimestampCheck record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<TimestampCheck>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<TimestampCheck>> Where(
			Expression<Func<TimestampCheck, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<TimestampCheck, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<TimestampCheck>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<TimestampCheck>();
		}

		private async Task<TimestampCheck> GetById(int id)
		{
			List<TimestampCheck> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>ba073b0b10277e9528603ec0949c72b8</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/