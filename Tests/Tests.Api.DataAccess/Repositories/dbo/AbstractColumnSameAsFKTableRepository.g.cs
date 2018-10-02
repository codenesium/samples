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
	public abstract class AbstractColumnSameAsFKTableRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractColumnSameAsFKTableRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<ColumnSameAsFKTable>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
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

		protected async Task<List<ColumnSameAsFKTable>> Where(
			Expression<Func<ColumnSameAsFKTable, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<ColumnSameAsFKTable, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<ColumnSameAsFKTable>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<ColumnSameAsFKTable>();
			}
			else
			{
				return await this.Context.Set<ColumnSameAsFKTable>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<ColumnSameAsFKTable>();
			}
		}

		private async Task<ColumnSameAsFKTable> GetById(int id)
		{
			List<ColumnSameAsFKTable> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>a1ef76330a7fda771aa8d601f1a5f849</Hash>
</Codenesium>*/