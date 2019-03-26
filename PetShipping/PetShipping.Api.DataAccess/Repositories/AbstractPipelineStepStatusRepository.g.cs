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
	public abstract class AbstractPipelineStepStatusRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractPipelineStepStatusRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<PipelineStepStatus>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.Id == query.ToInt() ||
				                  x.Name.StartsWith(query),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<PipelineStepStatus> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<PipelineStepStatus> Create(PipelineStepStatus item)
		{
			this.Context.Set<PipelineStepStatus>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(PipelineStepStatus item)
		{
			var entity = this.Context.Set<PipelineStepStatus>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<PipelineStepStatus>().Attach(item);
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
			PipelineStepStatus record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<PipelineStepStatus>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to this table PipelineStep via pipelineStepStatusId.
		public async virtual Task<List<PipelineStep>> PipelineStepsByPipelineStepStatusId(int pipelineStepStatusId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<PipelineStep>()
			       .Include(x => x.PipelineStepStatusIdNavigation)
			       .Include(x => x.ShipperIdNavigation)

			       .Where(x => x.PipelineStepStatusId == pipelineStepStatusId).AsQueryable().Skip(offset).Take(limit).ToListAsync<PipelineStep>();
		}

		protected async Task<List<PipelineStepStatus>> Where(
			Expression<Func<PipelineStepStatus, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<PipelineStepStatus, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<PipelineStepStatus>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<PipelineStepStatus>();
		}

		private async Task<PipelineStepStatus> GetById(int id)
		{
			List<PipelineStepStatus> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>7d5c7735e41c91d11ad8ea2ae8e3bb5e</Hash>
</Codenesium>*/