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
	public abstract class AbstractPipelineStepDestinationRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }

		public AbstractPipelineStepDestinationRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<PipelineStepDestination>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqEF(x => true, skip, take, orderClause);
		}

		public async virtual Task<PipelineStepDestination> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<PipelineStepDestination> Create(PipelineStepDestination item)
		{
			this.Context.Set<PipelineStepDestination>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(PipelineStepDestination item)
		{
			var entity = this.Context.Set<PipelineStepDestination>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<PipelineStepDestination>().Attach(item);
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
			PipelineStepDestination record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<PipelineStepDestination>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<PipelineStepDestination>> Where(Expression<Func<PipelineStepDestination, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<PipelineStepDestination> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<PipelineStepDestination>> SearchLinqEF(Expression<Func<PipelineStepDestination, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PipelineStepDestination.Id)} ASC";
			}
			return await this.Context.Set<PipelineStepDestination>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<PipelineStepDestination>();
		}

		private async Task<List<PipelineStepDestination>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PipelineStepDestination.Id)} ASC";
			}

			return await this.Context.Set<PipelineStepDestination>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<PipelineStepDestination>();
		}

		private async Task<PipelineStepDestination> GetById(int id)
		{
			List<PipelineStepDestination> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>1de5ce798200bc34999e7f7ba304e3e7</Hash>
</Codenesium>*/