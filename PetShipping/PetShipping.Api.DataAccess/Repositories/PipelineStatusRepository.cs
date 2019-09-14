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

namespace PetShippingNS.Api.DataAccess
{
	public class PipelineStatusRepository : AbstractRepository, IPipelineStatusRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public PipelineStatusRepository(
			ILogger<IPipelineStatusRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<PipelineStatus>> All(int limit = int.MaxValue, int offset = 0, string query = "")
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

		public async virtual Task<PipelineStatus> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<PipelineStatus> Create(PipelineStatus item)
		{
			this.Context.Set<PipelineStatus>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(PipelineStatus item)
		{
			var entity = this.Context.Set<PipelineStatus>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<PipelineStatus>().Attach(item);
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
			PipelineStatus record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<PipelineStatus>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to this table Pipeline via pipelineStatusId.
		public async virtual Task<List<Pipeline>> PipelinesByPipelineStatusId(int pipelineStatusId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Pipeline>()
			       .Include(x => x.PipelineStatusIdNavigation)

			       .Where(x => x.PipelineStatusId == pipelineStatusId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Pipeline>();
		}

		protected async Task<List<PipelineStatus>> Where(
			Expression<Func<PipelineStatus, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<PipelineStatus, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<PipelineStatus>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<PipelineStatus>();
		}

		private async Task<PipelineStatus> GetById(int id)
		{
			List<PipelineStatus> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>ee1088a185bd22318e0009ddd14eb722</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/