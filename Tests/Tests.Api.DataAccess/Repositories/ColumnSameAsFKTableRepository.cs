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
	public class ColumnSameAsFKTableRepository : AbstractRepository, IColumnSameAsFKTableRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public ColumnSameAsFKTableRepository(
			ILogger<IColumnSameAsFKTableRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<ColumnSameAsFKTable>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  (x.PersonNavigation == null || x.PersonNavigation.PersonName == null?false : x.PersonNavigation.PersonName.StartsWith(query)) ||
				                  (x.PersonIdNavigation == null || x.PersonIdNavigation.PersonName == null?false : x.PersonIdNavigation.PersonName.StartsWith(query)),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<ColumnSameAsFKTable> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<ColumnSameAsFKTable> Create(ColumnSameAsFKTable item)
		{
			this.Context.Set<ColumnSameAsFKTable>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(ColumnSameAsFKTable item)
		{
			var entity = this.Context.Set<ColumnSameAsFKTable>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<ColumnSameAsFKTable>().Attach(item);
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
			ColumnSameAsFKTable record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ColumnSameAsFKTable>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to table Person via person.
		public async virtual Task<Person> PersonByPerson(int person)
		{
			return await this.Context.Set<Person>()
			       .SingleOrDefaultAsync(x => x.PersonId == person);
		}

		// Foreign key reference to table Person via personId.
		public async virtual Task<Person> PersonByPersonId(int personId)
		{
			return await this.Context.Set<Person>()
			       .SingleOrDefaultAsync(x => x.PersonId == personId);
		}

		protected async Task<List<ColumnSameAsFKTable>> Where(
			Expression<Func<ColumnSameAsFKTable, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<ColumnSameAsFKTable, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<ColumnSameAsFKTable>()
			       .Include(x => x.PersonNavigation)
			       .Include(x => x.PersonIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<ColumnSameAsFKTable>();
		}

		private async Task<ColumnSameAsFKTable> GetById(int id)
		{
			List<ColumnSameAsFKTable> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>b6497c30136cf2b941b4367903f124c3</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/