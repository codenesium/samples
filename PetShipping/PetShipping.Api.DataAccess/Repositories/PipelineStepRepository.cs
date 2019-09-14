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
	public class PipelineStepRepository : AbstractRepository, IPipelineStepRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public PipelineStepRepository(
			ILogger<IPipelineStepRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<PipelineStep>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  (x.Name == null?false : x.Name.StartsWith(query)) ||
				                  (x.PipelineStepStatusIdNavigation == null || x.PipelineStepStatusIdNavigation.Name == null?false : x.PipelineStepStatusIdNavigation.Name.StartsWith(query)) ||
				                  (x.ShipperIdNavigation == null || x.ShipperIdNavigation.LastName == null?false : x.ShipperIdNavigation.LastName.StartsWith(query)),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<PipelineStep> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<PipelineStep> Create(PipelineStep item)
		{
			this.Context.Set<PipelineStep>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(PipelineStep item)
		{
			var entity = this.Context.Set<PipelineStep>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<PipelineStep>().Attach(item);
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
			PipelineStep record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<PipelineStep>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to this table HandlerPipelineStep via pipelineStepId.
		public async virtual Task<List<HandlerPipelineStep>> HandlerPipelineStepsByPipelineStepId(int pipelineStepId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<HandlerPipelineStep>()
			       .Include(x => x.HandlerIdNavigation)
			       .Include(x => x.PipelineStepIdNavigation)

			       .Where(x => x.PipelineStepId == pipelineStepId).AsQueryable().Skip(offset).Take(limit).ToListAsync<HandlerPipelineStep>();
		}

		// Foreign key reference to this table OtherTransport via pipelineStepId.
		public async virtual Task<List<OtherTransport>> OtherTransportsByPipelineStepId(int pipelineStepId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<OtherTransport>()
			       .Include(x => x.HandlerIdNavigation)
			       .Include(x => x.PipelineStepIdNavigation)

			       .Where(x => x.PipelineStepId == pipelineStepId).AsQueryable().Skip(offset).Take(limit).ToListAsync<OtherTransport>();
		}

		// Foreign key reference to this table PipelineStepDestination via pipelineStepId.
		public async virtual Task<List<PipelineStepDestination>> PipelineStepDestinationsByPipelineStepId(int pipelineStepId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<PipelineStepDestination>()
			       .Include(x => x.DestinationIdNavigation)
			       .Include(x => x.PipelineStepIdNavigation)

			       .Where(x => x.PipelineStepId == pipelineStepId).AsQueryable().Skip(offset).Take(limit).ToListAsync<PipelineStepDestination>();
		}

		// Foreign key reference to this table PipelineStepNote via pipelineStepId.
		public async virtual Task<List<PipelineStepNote>> PipelineStepNotesByPipelineStepId(int pipelineStepId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<PipelineStepNote>()
			       .Include(x => x.EmployeeIdNavigation)
			       .Include(x => x.PipelineStepIdNavigation)

			       .Where(x => x.PipelineStepId == pipelineStepId).AsQueryable().Skip(offset).Take(limit).ToListAsync<PipelineStepNote>();
		}

		// Foreign key reference to this table PipelineStepStepRequirement via pipelineStepId.
		public async virtual Task<List<PipelineStepStepRequirement>> PipelineStepStepRequirementsByPipelineStepId(int pipelineStepId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<PipelineStepStepRequirement>()
			       .Include(x => x.PipelineStepIdNavigation)

			       .Where(x => x.PipelineStepId == pipelineStepId).AsQueryable().Skip(offset).Take(limit).ToListAsync<PipelineStepStepRequirement>();
		}

		// Foreign key reference to table PipelineStepStatus via pipelineStepStatusId.
		public async virtual Task<PipelineStepStatus> PipelineStepStatusByPipelineStepStatusId(int pipelineStepStatusId)
		{
			return await this.Context.Set<PipelineStepStatus>()
			       .SingleOrDefaultAsync(x => x.Id == pipelineStepStatusId);
		}

		// Foreign key reference to table Employee via shipperId.
		public async virtual Task<Employee> EmployeeByShipperId(int shipperId)
		{
			return await this.Context.Set<Employee>()
			       .SingleOrDefaultAsync(x => x.Id == shipperId);
		}

		protected async Task<List<PipelineStep>> Where(
			Expression<Func<PipelineStep, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<PipelineStep, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<PipelineStep>()
			       .Include(x => x.PipelineStepStatusIdNavigation)
			       .Include(x => x.ShipperIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<PipelineStep>();
		}

		private async Task<PipelineStep> GetById(int id)
		{
			List<PipelineStep> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>e0d62a63cf564fc96550bd50c26be361</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/