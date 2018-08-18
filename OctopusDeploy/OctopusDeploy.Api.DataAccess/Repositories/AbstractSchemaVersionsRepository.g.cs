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

namespace OctopusDeployNS.Api.DataAccess
{
	public abstract class AbstractSchemaVersionsRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractSchemaVersionsRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<SchemaVersions>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<SchemaVersions> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<SchemaVersions> Create(SchemaVersions item)
		{
			this.Context.Set<SchemaVersions>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(SchemaVersions item)
		{
			var entity = this.Context.Set<SchemaVersions>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<SchemaVersions>().Attach(item);
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
			SchemaVersions record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SchemaVersions>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<SchemaVersions>> Where(
			Expression<Func<SchemaVersions, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<SchemaVersions, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<SchemaVersions>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<SchemaVersions>();
			}
			else
			{
				return await this.Context.Set<SchemaVersions>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<SchemaVersions>();
			}
		}

		private async Task<SchemaVersions> GetById(int id)
		{
			List<SchemaVersions> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>881a1ecc8a7ac30a72cae8aa7d932a4b</Hash>
</Codenesium>*/