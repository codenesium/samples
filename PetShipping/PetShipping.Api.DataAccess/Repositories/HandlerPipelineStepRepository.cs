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
	public class HandlerPipelineStepRepository : AbstractRepository, IHandlerPipelineStepRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public HandlerPipelineStepRepository(
			ILogger<IHandlerPipelineStepRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<HandlerPipelineStep>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  (x.HandlerIdNavigation == null || x.HandlerIdNavigation.Email == null?false : x.HandlerIdNavigation.Email.StartsWith(query)) ||
				                  (x.PipelineStepIdNavigation == null || x.PipelineStepIdNavigation.Name == null?false : x.PipelineStepIdNavigation.Name.StartsWith(query)),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<HandlerPipelineStep> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<HandlerPipelineStep> Create(HandlerPipelineStep item)
		{
			this.Context.Set<HandlerPipelineStep>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(HandlerPipelineStep item)
		{
			var entity = this.Context.Set<HandlerPipelineStep>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<HandlerPipelineStep>().Attach(item);
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
			HandlerPipelineStep record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<HandlerPipelineStep>().Remove(record);
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

		protected async Task<List<HandlerPipelineStep>> Where(
			Expression<Func<HandlerPipelineStep, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<HandlerPipelineStep, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<HandlerPipelineStep>()
			       .Include(x => x.HandlerIdNavigation)
			       .Include(x => x.PipelineStepIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<HandlerPipelineStep>();
		}

		private async Task<HandlerPipelineStep> GetById(int id)
		{
			List<HandlerPipelineStep> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>d0096a5b65e70544493437e994e8e14f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/