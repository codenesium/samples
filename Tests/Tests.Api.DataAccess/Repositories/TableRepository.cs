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
	public class TableRepository : AbstractRepository, ITableRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public TableRepository(
			ILogger<ITableRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Table>> All(int limit = int.MaxValue, int offset = 0, string query = "")
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

		public async virtual Task<Table> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Table> Create(Table item)
		{
			this.Context.Set<Table>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Table item)
		{
			var entity = this.Context.Set<Table>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Table>().Attach(item);
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
			Table record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Table>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<Table>> Where(
			Expression<Func<Table, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Table, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Table>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Table>();
		}

		private async Task<Table> GetById(int id)
		{
			List<Table> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>95010073c6b78eadcef8050e1c4ad64e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/