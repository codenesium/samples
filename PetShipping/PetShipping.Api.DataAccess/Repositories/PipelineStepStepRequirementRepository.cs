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
	public class PipelineStepStepRequirementRepository : AbstractRepository, IPipelineStepStepRequirementRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public PipelineStepStepRequirementRepository(
			ILogger<IPipelineStepStepRequirementRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<PipelineStepStepRequirement>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  (x.Details == null?false : x.Details.StartsWith(query)) ||
				                  (x.PipelineStepIdNavigation == null || x.PipelineStepIdNavigation.Name == null?false : x.PipelineStepIdNavigation.Name.StartsWith(query)) ||
				                  x.RequirementMet == query.ToBoolean(),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<PipelineStepStepRequirement> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<PipelineStepStepRequirement> Create(PipelineStepStepRequirement item)
		{
			this.Context.Set<PipelineStepStepRequirement>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(PipelineStepStepRequirement item)
		{
			var entity = this.Context.Set<PipelineStepStepRequirement>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<PipelineStepStepRequirement>().Attach(item);
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
			PipelineStepStepRequirement record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<PipelineStepStepRequirement>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to table PipelineStep via pipelineStepId.
		public async virtual Task<PipelineStep> PipelineStepByPipelineStepId(int pipelineStepId)
		{
			return await this.Context.Set<PipelineStep>()
			       .SingleOrDefaultAsync(x => x.Id == pipelineStepId);
		}

		protected async Task<List<PipelineStepStepRequirement>> Where(
			Expression<Func<PipelineStepStepRequirement, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<PipelineStepStepRequirement, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<PipelineStepStepRequirement>()
			       .Include(x => x.PipelineStepIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<PipelineStepStepRequirement>();
		}

		private async Task<PipelineStepStepRequirement> GetById(int id)
		{
			List<PipelineStepStepRequirement> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>614151e77d0588d1c7927815fb44c4d7</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/