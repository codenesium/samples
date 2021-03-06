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

namespace NebulaNS.Api.DataAccess
{
	public class ChainStatusRepository : AbstractRepository, IChainStatusRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public ChainStatusRepository(
			ILogger<IChainStatusRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<ChainStatus>> All(int limit = int.MaxValue, int offset = 0, string query = "")
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

		public async virtual Task<ChainStatus> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<ChainStatus> Create(ChainStatus item)
		{
			this.Context.Set<ChainStatus>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(ChainStatus item)
		{
			var entity = this.Context.Set<ChainStatus>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<ChainStatus>().Attach(item);
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
			ChainStatus record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ChainStatus>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// unique constraint AX_ChainStatus_Name.
		public async virtual Task<ChainStatus> ByName(string name)
		{
			return await this.Context.Set<ChainStatus>()

			       .FirstOrDefaultAsync(x => x.Name == name);
		}

		// Foreign key reference to this table Chain via chainStatusId.
		public async virtual Task<List<Chain>> ChainsByChainStatusId(int chainStatusId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Chain>()
			       .Include(x => x.ChainStatusIdNavigation)
			       .Include(x => x.TeamIdNavigation)

			       .Where(x => x.ChainStatusId == chainStatusId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Chain>();
		}

		protected async Task<List<ChainStatus>> Where(
			Expression<Func<ChainStatus, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<ChainStatus, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<ChainStatus>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<ChainStatus>();
		}

		private async Task<ChainStatus> GetById(int id)
		{
			List<ChainStatus> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>ef9f1a7beff9efc6d1e2388d301579ed</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/