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
	public class PipelineStepDestinationRepository : AbstractRepository, IPipelineStepDestinationRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public PipelineStepDestinationRepository(
			ILogger<IPipelineStepDestinationRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<PipelineStepDestination>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  (x.DestinationIdNavigation == null || x.DestinationIdNavigation.Name == null?false : x.DestinationIdNavigation.Name.StartsWith(query)) ||
				                  (x.PipelineStepIdNavigation == null || x.PipelineStepIdNavigation.Name == null?false : x.PipelineStepIdNavigation.Name.StartsWith(query)),
				                  limit,
				                  offset);
			}
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

		// Foreign key reference to table Destination via destinationId.
		public async virtual Task<Destination> DestinationByDestinationId(int destinationId)
		{
			return await this.Context.Set<Destination>()
			       .SingleOrDefaultAsync(x => x.Id == destinationId);
		}

		// Foreign key reference to table PipelineStep via pipelineStepId.
		public async virtual Task<PipelineStep> PipelineStepByPipelineStepId(int pipelineStepId)
		{
			return await this.Context.Set<PipelineStep>()
			       .SingleOrDefaultAsync(x => x.Id == pipelineStepId);
		}

		protected async Task<List<PipelineStepDestination>> Where(
			Expression<Func<PipelineStepDestination, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<PipelineStepDestination, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<PipelineStepDestination>()
			       .Include(x => x.DestinationIdNavigation)
			       .Include(x => x.PipelineStepIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<PipelineStepDestination>();
		}

		private async Task<PipelineStepDestination> GetById(int id)
		{
			List<PipelineStepDestination> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>76c234533a28cc0b195880f36026bc00</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/