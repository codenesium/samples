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
	public abstract class AbstractPasswordRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractPasswordRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Password>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.BusinessEntityID == query.ToInt() ||
				                  x.ModifiedDate == query.ToDateTime() ||
				                  x.PasswordHash.StartsWith(query) ||
				                  x.PasswordSalt.StartsWith(query) ||
				                  x.Rowguid == query.ToGuid(),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Password> Get(int businessEntityID)
		{
			return await this.GetById(businessEntityID);
		}

		public async virtual Task<Password> Create(Password item)
		{
			this.Context.Set<Password>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Password item)
		{
			var entity = this.Context.Set<Password>().Local.FirstOrDefault(x => x.BusinessEntityID == item.BusinessEntityID);
			if (entity == null)
			{
				this.Context.Set<Password>().Attach(item);
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
			Password record = await this.GetById(businessEntityID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Password>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to table Person via businessEntityID.
		public async virtual Task<Person> PersonByBusinessEntityID(int businessEntityID)
		{
			return await this.Context.Set<Person>()
			       .SingleOrDefaultAsync(x => x.BusinessEntityID == businessEntityID);
		}

		protected async Task<List<Password>> Where(
			Expression<Func<Password, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Password, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.BusinessEntityID;
			}

			return await this.Context.Set<Password>()
			       .Include(x => x.BusinessEntityIDNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Password>();
		}

		private async Task<Password> GetById(int businessEntityID)
		{
			List<Password> records = await this.Where(x => x.BusinessEntityID == businessEntityID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>40e068a81a28ee6ef82ecf6aae58cecd</Hash>
</Codenesium>*/