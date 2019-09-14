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

namespace StackOverflowNS.Api.DataAccess
{
	public class VoteTypeRepository : AbstractRepository, IVoteTypeRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public VoteTypeRepository(
			ILogger<IVoteTypeRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<VoteType>> All(int limit = int.MaxValue, int offset = 0, string query = "")
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

		public async virtual Task<VoteType> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<VoteType> Create(VoteType item)
		{
			this.Context.Set<VoteType>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(VoteType item)
		{
			var entity = this.Context.Set<VoteType>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<VoteType>().Attach(item);
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
			VoteType record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<VoteType>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to this table Vote via voteTypeId.
		public async virtual Task<List<Vote>> VotesByVoteTypeId(int voteTypeId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Vote>()
			       .Include(x => x.PostIdNavigation)
			       .Include(x => x.UserIdNavigation)
			       .Include(x => x.VoteTypeIdNavigation)

			       .Where(x => x.VoteTypeId == voteTypeId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Vote>();
		}

		protected async Task<List<VoteType>> Where(
			Expression<Func<VoteType, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<VoteType, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<VoteType>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<VoteType>();
		}

		private async Task<VoteType> GetById(int id)
		{
			List<VoteType> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>fc17ff76877492d228b25ea20068f626</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/