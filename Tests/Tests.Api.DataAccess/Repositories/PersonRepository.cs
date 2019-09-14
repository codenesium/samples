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
	public class PersonRepository : AbstractRepository, IPersonRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public PersonRepository(
			ILogger<IPersonRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Person>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  (x.PersonName == null?false : x.PersonName.StartsWith(query)),
				                  limit,
				                  offset);
			}
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

		// Foreign key reference to this table ColumnSameAsFKTable via person.
		public async virtual Task<List<ColumnSameAsFKTable>> ColumnSameAsFKTablesByPerson(int person, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<ColumnSameAsFKTable>()
			       .Include(x => x.PersonNavigation)
			       .Include(x => x.PersonIdNavigation)

			       .Where(x => x.Person == person).AsQueryable().Skip(offset).Take(limit).ToListAsync<ColumnSameAsFKTable>();
		}

		// Foreign key reference to this table ColumnSameAsFKTable via personId.
		public async virtual Task<List<ColumnSameAsFKTable>> ColumnSameAsFKTablesByPersonId(int personId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<ColumnSameAsFKTable>()
			       .Include(x => x.PersonNavigation)
			       .Include(x => x.PersonIdNavigation)

			       .Where(x => x.PersonId == personId).AsQueryable().Skip(offset).Take(limit).ToListAsync<ColumnSameAsFKTable>();
		}

		protected async Task<List<Person>> Where(
			Expression<Func<Person, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Person, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.PersonId;
			}

			return await this.Context.Set<Person>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Person>();
		}

		private async Task<Person> GetById(int personId)
		{
			List<Person> records = await this.Where(x => x.PersonId == personId);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>b527205bc3d97af0b53e608c91e70f7f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/