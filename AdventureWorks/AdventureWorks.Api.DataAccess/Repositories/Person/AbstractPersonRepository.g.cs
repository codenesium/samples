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

namespace AdventureWorksNS.Api.DataAccess
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

		public async virtual Task<Person> Get(int businessEntityID)
		{
			return await this.GetById(businessEntityID);
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
			var entity = this.Context.Set<Person>().Local.FirstOrDefault(x => x.BusinessEntityID == item.BusinessEntityID);
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
			int businessEntityID)
		{
			Person record = await this.GetById(businessEntityID);

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

		// unique constraint AK_Person_rowguid.
		public async virtual Task<Person> ByRowguid(Guid rowguid)
		{
			return await this.Context.Set<Person>().SingleOrDefaultAsync(x => x.Rowguid == rowguid);
		}

		// Non-unique constraint IX_Person_LastName_FirstName_MiddleName.
		public async virtual Task<List<Person>> ByLastNameFirstNameMiddleName(string lastName, string firstName, string middleName, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.LastName == lastName && x.FirstName == firstName && x.MiddleName == middleName, limit, offset);
		}

		// Non-unique constraint PXML_Person_AddContact.
		public async virtual Task<List<Person>> ByAdditionalContactInfo(string additionalContactInfo, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.AdditionalContactInfo == additionalContactInfo, limit, offset);
		}

		// Non-unique constraint PXML_Person_Demographics.
		public async virtual Task<List<Person>> ByDemographic(string demographic, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.Demographic == demographic, limit, offset);
		}

		// Foreign key reference to this table Password via businessEntityID.
		public async virtual Task<List<Password>> PasswordsByBusinessEntityID(int businessEntityID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Password>().Where(x => x.BusinessEntityID == businessEntityID).AsQueryable().Skip(offset).Take(limit).ToListAsync<Password>();
		}

		protected async Task<List<Person>> Where(
			Expression<Func<Person, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Person, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.BusinessEntityID;
			}

			return await this.Context.Set<Person>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Person>();
		}

		private async Task<Person> GetById(int businessEntityID)
		{
			List<Person> records = await this.Where(x => x.BusinessEntityID == businessEntityID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>e991ff9e6c28a9ad67769481239b1800</Hash>
</Codenesium>*/