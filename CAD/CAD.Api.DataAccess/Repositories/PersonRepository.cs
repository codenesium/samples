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

namespace CADNS.Api.DataAccess
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
				                  (x.FirstName == null?false : x.FirstName.StartsWith(query)) ||
				                  (x.LastName == null?false : x.LastName.StartsWith(query)) ||
				                  (x.Phone == null?false : x.Phone.StartsWith(query)) ||
				                  (x.Ssn == null?false : x.Ssn.StartsWith(query)),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Person> Get(int id)
		{
			return await this.GetById(id);
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
			var entity = this.Context.Set<Person>().Local.FirstOrDefault(x => x.Id == item.Id);
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
			int id)
		{
			Person record = await this.GetById(id);

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

		// Foreign key reference to this table CallPerson via personId.
		public async virtual Task<List<CallPerson>> CallPersonsByPersonId(int personId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<CallPerson>()
			       .Include(x => x.PersonIdNavigation)
			       .Include(x => x.PersonTypeIdNavigation)

			       .Where(x => x.PersonId == personId).AsQueryable().Skip(offset).Take(limit).ToListAsync<CallPerson>();
		}

		protected async Task<List<Person>> Where(
			Expression<Func<Person, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Person, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Person>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Person>();
		}

		private async Task<Person> GetById(int id)
		{
			List<Person> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>9a6a50d7e2ab9811e6b539cdfd610487</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/