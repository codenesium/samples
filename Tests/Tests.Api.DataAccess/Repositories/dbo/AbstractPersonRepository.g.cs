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
	public abstract class AbstractPersonRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractPersonRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Person>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<Person> Get(int personId)
		{
			return await this.GetById(personId);
		}

		public async virtual Task<Person> Create(Person item)
		{
			this.Context.Set<Person>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Person item)
		{
			var entity = this.Context.Set<Person>().Local.FirstOrDefault(x => x.PersonId == item.PersonId);
			if (entity == null)
			{
				this.Context.Set<Person>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int personId)
		{
			Person record = await this.GetById(personId);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Person>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<Person>> Where(
			Expression<Func<Person, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Person, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.PersonId;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<Person>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Person>();
			}
			else
			{
				return await this.Context.Set<Person>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Person>();
			}
		}

		private async Task<Person> GetById(int personId)
		{
			List<Person> records = await this.Where(x => x.PersonId == personId);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>4ad19d0d0e194cb09a630194f77619db</Hash>
</Codenesium>*/