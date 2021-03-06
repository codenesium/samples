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
	public class ClaspRepository : AbstractRepository, IClaspRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public ClaspRepository(
			ILogger<IClaspRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Clasp>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  (x.NextChainIdNavigation == null || x.NextChainIdNavigation.Name == null?false : x.NextChainIdNavigation.Name.StartsWith(query)) ||
				                  (x.PreviousChainIdNavigation == null || x.PreviousChainIdNavigation.Name == null?false : x.PreviousChainIdNavigation.Name.StartsWith(query)),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Clasp> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Clasp> Create(Clasp item)
		{
			this.Context.Set<Clasp>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Clasp item)
		{
			var entity = this.Context.Set<Clasp>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Clasp>().Attach(item);
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
			Clasp record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Clasp>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to table Chain via nextChainId.
		public async virtual Task<Chain> ChainByNextChainId(int nextChainId)
		{
			return await this.Context.Set<Chain>()
			       .SingleOrDefaultAsync(x => x.Id == nextChainId);
		}

		// Foreign key reference to table Chain via previousChainId.
		public async virtual Task<Chain> ChainByPreviousChainId(int previousChainId)
		{
			return await this.Context.Set<Chain>()
			       .SingleOrDefaultAsync(x => x.Id == previousChainId);
		}

		protected async Task<List<Clasp>> Where(
			Expression<Func<Clasp, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Clasp, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Clasp>()
			       .Include(x => x.NextChainIdNavigation)
			       .Include(x => x.PreviousChainIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Clasp>();
		}

		private async Task<Clasp> GetById(int id)
		{
			List<Clasp> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>091ab07d9186598b4cea6e90d73f79ff</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/