using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public abstract class AbstractPipelineStepStepRequirementRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractPipelineStepStepRequirementRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOPipelineStepStepRequirement>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOPipelineStepStepRequirement> Get(int id)
		{
			PipelineStepStepRequirement record = await this.GetById(id);

			return this.Mapper.PipelineStepStepRequirementMapEFToPOCO(record);
		}

		public async virtual Task<POCOPipelineStepStepRequirement> Create(
			ApiPipelineStepStepRequirementModel model)
		{
			PipelineStepStepRequirement record = new PipelineStepStepRequirement();

			this.Mapper.PipelineStepStepRequirementMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<PipelineStepStepRequirement>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.PipelineStepStepRequirementMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int id,
			ApiPipelineStepStepRequirementModel model)
		{
			PipelineStepStepRequirement record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.PipelineStepStepRequirementMapModelToEF(
					id,
					model,
					record);

				await this.Context.SaveChangesAsync();
			}
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

		protected async Task<List<POCOPipelineStepStepRequirement>> Where(Expression<Func<PipelineStepStepRequirement, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPipelineStepStepRequirement> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOPipelineStepStepRequirement>> SearchLinqPOCO(Expression<Func<PipelineStepStepRequirement, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPipelineStepStepRequirement> response = new List<POCOPipelineStepStepRequirement>();
			List<PipelineStepStepRequirement> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.PipelineStepStepRequirementMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<PipelineStepStepRequirement>> SearchLinqEF(Expression<Func<PipelineStepStepRequirement, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PipelineStepStepRequirement.Id)} ASC";
			}
			return await this.Context.Set<PipelineStepStepRequirement>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<PipelineStepStepRequirement>();
		}

		private async Task<List<PipelineStepStepRequirement>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PipelineStepStepRequirement.Id)} ASC";
			}

			return await this.Context.Set<PipelineStepStepRequirement>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<PipelineStepStepRequirement>();
		}

		private async Task<PipelineStepStepRequirement> GetById(int id)
		{
			List<PipelineStepStepRequirement> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>b0c166701b4162f3d141d006e8c9be38</Hash>
</Codenesium>*/