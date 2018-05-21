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
	public abstract class AbstractPipelineStepRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractPipelineStepRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOPipelineStep>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOPipelineStep> Get(int id)
		{
			PipelineStep record = await this.GetById(id);

			return this.Mapper.PipelineStepMapEFToPOCO(record);
		}

		public async virtual Task<POCOPipelineStep> Create(
			ApiPipelineStepModel model)
		{
			PipelineStep record = new PipelineStep();

			this.Mapper.PipelineStepMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<PipelineStep>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.PipelineStepMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int id,
			ApiPipelineStepModel model)
		{
			PipelineStep record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.PipelineStepMapModelToEF(
					id,
					model,
					record);

				await this.Context.SaveChangesAsync();
			}
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

		protected async Task<List<POCOPipelineStep>> Where(Expression<Func<PipelineStep, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPipelineStep> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOPipelineStep>> SearchLinqPOCO(Expression<Func<PipelineStep, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPipelineStep> response = new List<POCOPipelineStep>();
			List<PipelineStep> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.PipelineStepMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<PipelineStep>> SearchLinqEF(Expression<Func<PipelineStep, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PipelineStep.Id)} ASC";
			}
			return await this.Context.Set<PipelineStep>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<PipelineStep>();
		}

		private async Task<List<PipelineStep>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PipelineStep.Id)} ASC";
			}

			return await this.Context.Set<PipelineStep>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<PipelineStep>();
		}

		private async Task<PipelineStep> GetById(int id)
		{
			List<PipelineStep> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>9d9497943a6e61a5b1a69d4ba50d1363</Hash>
</Codenesium>*/