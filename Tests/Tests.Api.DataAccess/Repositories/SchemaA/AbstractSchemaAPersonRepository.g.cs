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
	public abstract class AbstractSchemaAPersonRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractSchemaAPersonRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<SchemaAPerson>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<SchemaAPerson> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<SchemaAPerson> Create(SchemaAPerson item)
		{
			this.Context.Set<SchemaAPerson>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(SchemaAPerson item)
		{
			var entity = this.Context.Set<SchemaAPerson>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<SchemaAPerson>().Attach(item);
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
			SchemaAPerson record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SchemaAPerson>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<SchemaAPerson>> Where(
			Expression<Func<SchemaAPerson, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<SchemaAPerson, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<SchemaAPerson>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<SchemaAPerson>();
			}
			else
			{
				return await this.Context.Set<SchemaAPerson>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<SchemaAPerson>();
			}
		}

		private async Task<SchemaAPerson> GetById(int id)
		{
			List<SchemaAPerson> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>0d42004421127e1782dacb66729a35ff</Hash>
</Codenesium>*/