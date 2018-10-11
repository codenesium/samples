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
	public abstract class AbstractPersonPhoneRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractPersonPhoneRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<PersonPhone>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<PersonPhone> Get(int businessEntityID)
		{
			return await this.GetById(businessEntityID);
		}

		public async virtual Task<PersonPhone> Create(PersonPhone item)
		{
			this.Context.Set<PersonPhone>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(PersonPhone item)
		{
			var entity = this.Context.Set<PersonPhone>().Local.FirstOrDefault(x => x.BusinessEntityID == item.BusinessEntityID);
			if (entity == null)
			{
				this.Context.Set<PersonPhone>().Attach(item);
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
			PersonPhone record = await this.GetById(businessEntityID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<PersonPhone>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<List<PersonPhone>> ByPhoneNumber(string phoneNumber, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.PhoneNumber == phoneNumber, limit, offset);
		}

		protected async Task<List<PersonPhone>> Where(
			Expression<Func<PersonPhone, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<PersonPhone, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.BusinessEntityID;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<PersonPhone>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<PersonPhone>();
			}
			else
			{
				return await this.Context.Set<PersonPhone>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<PersonPhone>();
			}
		}

		private async Task<PersonPhone> GetById(int businessEntityID)
		{
			List<PersonPhone> records = await this.Where(x => x.BusinessEntityID == businessEntityID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>4008712ae92bc7168dcb8022cbdeab59</Hash>
</Codenesium>*/