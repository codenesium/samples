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
	public abstract class AbstractPipelineStepDestinationRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractPipelineStepDestinationRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<PipelineStepDestination>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
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

		public async virtual Task<Destination> GetDestination(int destinationId)
		{
			return await this.Context.Set<Destination>().SingleOrDefaultAsync(x => x.Id == destinationId);
		}

		public async virtual Task<PipelineStep> GetPipelineStep(int pipelineStepId)
		{
			return await this.Context.Set<PipelineStep>().SingleOrDefaultAsync(x => x.Id == pipelineStepId);
		}

		protected async Task<List<PipelineStepDestination>> Where(
			Expression<Func<PipelineStepDestination, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<PipelineStepDestination, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<PipelineStepDestination>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<PipelineStepDestination>();
			}
			else
			{
				return await this.Context.Set<PipelineStepDestination>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<PipelineStepDestination>();
			}
		}

		private async Task<PipelineStepDestination> GetById(int id)
		{
			List<PipelineStepDestination> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>d8975f3f108124c1413efbf1df0940f2</Hash>
</Codenesium>*/