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
	public class PersonTypeRepository : AbstractRepository, IPersonTypeRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public PersonTypeRepository(
			ILogger<IPersonTypeRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<PersonType>> All(int limit = int.MaxValue, int offset = 0, string query = "")
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

		public async virtual Task<PersonType> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<PersonType> Create(PersonType item)
		{
			this.Context.Set<PersonType>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(PersonType item)
		{
			var entity = this.Context.Set<PersonType>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<PersonType>().Attach(item);
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
			PersonType record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<PersonType>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to this table CallPerson via personTypeId.
		public async virtual Task<List<CallPerson>> CallPersonsByPersonTypeId(int personTypeId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<CallPerson>()
			       .Include(x => x.PersonIdNavigation)
			       .Include(x => x.PersonTypeIdNavigation)

			       .Where(x => x.PersonTypeId == personTypeId).AsQueryable().Skip(offset).Take(limit).ToListAsync<CallPerson>();
		}

		protected async Task<List<PersonType>> Where(
			Expression<Func<PersonType, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<PersonType, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<PersonType>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<PersonType>();
		}

		private async Task<PersonType> GetById(int id)
		{
			List<PersonType> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>20bc9b356714284695911862d30429c3</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/