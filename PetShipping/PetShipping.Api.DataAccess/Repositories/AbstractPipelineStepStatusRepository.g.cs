using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public abstract class AbstractPipelineStepStatusRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }

		public AbstractPipelineStepStatusRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<PipelineStepStatus>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqEF(x => true, skip, take, orderClause);
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

		protected async Task<List<PipelineStepStatus>> Where(Expression<Func<PipelineStepStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<PipelineStepStatus> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<PipelineStepStatus>> SearchLinqEF(Expression<Func<PipelineStepStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PipelineStepStatus.Id)} ASC";
			}
			return await this.Context.Set<PipelineStepStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<PipelineStepStatus>();
		}

		private async Task<List<PipelineStepStatus>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PipelineStepStatus.Id)} ASC";
			}

			return await this.Context.Set<PipelineStepStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<PipelineStepStatus>();
		}

		private async Task<PipelineStepStatus> GetById(int id)
		{
			List<PipelineStepStatus> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>0dbeedd406702a2c03590952e2f29f86</Hash>
</Codenesium>*/