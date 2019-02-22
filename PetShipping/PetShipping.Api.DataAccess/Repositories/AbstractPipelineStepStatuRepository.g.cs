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
	public abstract class AbstractPipelineStepStatuRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractPipelineStepStatuRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<PipelineStepStatu>> All(int limit = int.MaxValue, int offset = 0, string query = "")
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

		public async virtual Task<PipelineStepStatu> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<PipelineStepStatu> Create(PipelineStepStatu item)
		{
			this.Context.Set<PipelineStepStatu>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(PipelineStepStatu item)
		{
			var entity = this.Context.Set<PipelineStepStatu>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<PipelineStepStatu>().Attach(item);
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
			PipelineStepStatu record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<PipelineStepStatu>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to this table PipelineStep via pipelineStepStatusId.
		public async virtual Task<List<PipelineStep>> PipelineStepsByPipelineStepStatusId(int pipelineStepStatusId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<PipelineStep>()
			       .Include(x => x.PipelineStepStatusIdNavigation)
			       .Where(x => x.PipelineStepStatusId == pipelineStepStatusId).AsQueryable().Skip(offset).Take(limit).ToListAsync<PipelineStep>();
		}

		protected async Task<List<PipelineStepStatu>> Where(
			Expression<Func<PipelineStepStatu, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<PipelineStepStatu, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<PipelineStepStatu>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<PipelineStepStatu>();
		}

		private async Task<PipelineStepStatu> GetById(int id)
		{
			List<PipelineStepStatu> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>8d5f09b1649b57afd30844969af7c2f3</Hash>
</Codenesium>*/