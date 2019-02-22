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
	public abstract class AbstractCallPersonRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractCallPersonRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<CallPerson>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.Id == query.ToInt() ||
				                  x.Note.StartsWith(query) ||
				                  x.PersonId == query.ToInt() ||
				                  x.PersonTypeId == query.ToInt(),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<CallPerson> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<CallPerson> Create(CallPerson item)
		{
			this.Context.Set<CallPerson>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(CallPerson item)
		{
			var entity = this.Context.Set<CallPerson>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<CallPerson>().Attach(item);
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
			CallPerson record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<CallPerson>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to table Person via personId.
		public async virtual Task<Person> PersonByPersonId(int personId)
		{
			return await this.Context.Set<Person>()
			       .SingleOrDefaultAsync(x => x.Id == personId);
		}

		// Foreign key reference to table PersonType via personTypeId.
		public async virtual Task<PersonType> PersonTypeByPersonTypeId(int personTypeId)
		{
			return await this.Context.Set<PersonType>()
			       .SingleOrDefaultAsync(x => x.Id == personTypeId);
		}

		protected async Task<List<CallPerson>> Where(
			Expression<Func<CallPerson, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<CallPerson, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<CallPerson>()
			       .Include(x => x.PersonIdNavigation)
			       .Include(x => x.PersonTypeIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<CallPerson>();
		}

		private async Task<CallPerson> GetById(int id)
		{
			List<CallPerson> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>6bb908ee06bf2e71b7ee9258f6736d68</Hash>
</Codenesium>*/