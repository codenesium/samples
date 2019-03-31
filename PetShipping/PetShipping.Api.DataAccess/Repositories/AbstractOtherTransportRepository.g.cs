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
	public abstract class AbstractOtherTransportRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractOtherTransportRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<OtherTransport>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.HandlerId == query.ToInt() ||
				                  x.PipelineStepId == query.ToInt(),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<OtherTransport> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<OtherTransport> Create(OtherTransport item)
		{
			this.Context.Set<OtherTransport>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(OtherTransport item)
		{
			var entity = this.Context.Set<OtherTransport>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<OtherTransport>().Attach(item);
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
			OtherTransport record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<OtherTransport>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to table Handler via handlerId.
		public async virtual Task<Handler> HandlerByHandlerId(int handlerId)
		{
			return await this.Context.Set<Handler>()
			       .SingleOrDefaultAsync(x => x.Id == handlerId);
		}

		// Foreign key reference to table PipelineStep via pipelineStepId.
		public async virtual Task<PipelineStep> PipelineStepByPipelineStepId(int pipelineStepId)
		{
			return await this.Context.Set<PipelineStep>()
			       .SingleOrDefaultAsync(x => x.Id == pipelineStepId);
		}

		protected async Task<List<OtherTransport>> Where(
			Expression<Func<OtherTransport, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<OtherTransport, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<OtherTransport>()
			       .Include(x => x.HandlerIdNavigation)
			       .Include(x => x.PipelineStepIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<OtherTransport>();
		}

		private async Task<OtherTransport> GetById(int id)
		{
			List<OtherTransport> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>88ded8dc7a5a6b499e49aa4944a2be6c</Hash>
</Codenesium>*/