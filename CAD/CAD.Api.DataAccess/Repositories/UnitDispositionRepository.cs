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
	public class UnitDispositionRepository : AbstractRepository, IUnitDispositionRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public UnitDispositionRepository(
			ILogger<IUnitDispositionRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<UnitDisposition>> All(int limit = int.MaxValue, int offset = 0, string query = "")
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

		public async virtual Task<UnitDisposition> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<UnitDisposition> Create(UnitDisposition item)
		{
			this.Context.Set<UnitDisposition>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(UnitDisposition item)
		{
			var entity = this.Context.Set<UnitDisposition>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<UnitDisposition>().Attach(item);
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
			UnitDisposition record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<UnitDisposition>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<UnitDisposition>> Where(
			Expression<Func<UnitDisposition, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<UnitDisposition, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<UnitDisposition>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<UnitDisposition>();
		}

		private async Task<UnitDisposition> GetById(int id)
		{
			List<UnitDisposition> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>0398c659c9021bb649a51d303d95e08b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/