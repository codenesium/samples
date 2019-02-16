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
	public abstract class AbstractContactTypeRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractContactTypeRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<ContactType>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.ContactTypeID == query.ToInt() ||
				                  x.ModifiedDate == query.ToDateTime() ||
				                  x.Name.StartsWith(query),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<ContactType> Get(int contactTypeID)
		{
			return await this.GetById(contactTypeID);
		}

		public async virtual Task<ContactType> Create(ContactType item)
		{
			this.Context.Set<ContactType>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(ContactType item)
		{
			var entity = this.Context.Set<ContactType>().Local.FirstOrDefault(x => x.ContactTypeID == item.ContactTypeID);
			if (entity == null)
			{
				this.Context.Set<ContactType>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int contactTypeID)
		{
			ContactType record = await this.GetById(contactTypeID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ContactType>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// unique constraint AK_ContactType_Name.
		public async virtual Task<ContactType> ByName(string name)
		{
			return await this.Context.Set<ContactType>().FirstOrDefaultAsync(x => x.Name == name);
		}

		protected async Task<List<ContactType>> Where(
			Expression<Func<ContactType, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<ContactType, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.ContactTypeID;
			}

			return await this.Context.Set<ContactType>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<ContactType>();
		}

		private async Task<ContactType> GetById(int contactTypeID)
		{
			List<ContactType> records = await this.Where(x => x.ContactTypeID == contactTypeID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>8456dadcfc36369a042cbafd94a4f495</Hash>
</Codenesium>*/