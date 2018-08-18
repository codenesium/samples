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
	public abstract class AbstractPersonRefRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractPersonRefRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<PersonRef>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<PersonRef> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<PersonRef> Create(PersonRef item)
		{
			this.Context.Set<PersonRef>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(PersonRef item)
		{
			var entity = this.Context.Set<PersonRef>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<PersonRef>().Attach(item);
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
			PersonRef record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<PersonRef>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task<SchemaBPerson> GetSchemaBPerson(int personBId)
		{
			return await this.Context.Set<SchemaBPerson>().SingleOrDefaultAsync(x => x.Id == personBId);
		}

		protected async Task<List<PersonRef>> Where(
			Expression<Func<PersonRef, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<PersonRef, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<PersonRef>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<PersonRef>();
			}
			else
			{
				return await this.Context.Set<PersonRef>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<PersonRef>();
			}
		}

		private async Task<PersonRef> GetById(int id)
		{
			List<PersonRef> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>bfb3b8a901105a151d99241171b26ea2</Hash>
</Codenesium>*/