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
	public abstract class AbstractSchemaBPersonRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractSchemaBPersonRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<SchemaBPerson>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<SchemaBPerson> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<SchemaBPerson> Create(SchemaBPerson item)
		{
			this.Context.Set<SchemaBPerson>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(SchemaBPerson item)
		{
			var entity = this.Context.Set<SchemaBPerson>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<SchemaBPerson>().Attach(item);
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
			SchemaBPerson record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SchemaBPerson>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task<List<PersonRef>> PersonRefs(int personBId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<PersonRef>().Where(x => x.PersonBId == personBId).AsQueryable().Skip(offset).Take(limit).ToListAsync<PersonRef>();
		}

		protected async Task<List<SchemaBPerson>> Where(
			Expression<Func<SchemaBPerson, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<SchemaBPerson, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<SchemaBPerson>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<SchemaBPerson>();
			}
			else
			{
				return await this.Context.Set<SchemaBPerson>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<SchemaBPerson>();
			}
		}

		private async Task<SchemaBPerson> GetById(int id)
		{
			List<SchemaBPerson> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>1b44a0b131d32c7fdc17aa84e1194a06</Hash>
</Codenesium>*/