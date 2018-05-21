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
	public abstract class AbstractHandlerPipelineStepRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractHandlerPipelineStepRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOHandlerPipelineStep>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOHandlerPipelineStep> Get(int id)
		{
			HandlerPipelineStep record = await this.GetById(id);

			return this.Mapper.HandlerPipelineStepMapEFToPOCO(record);
		}

		public async virtual Task<POCOHandlerPipelineStep> Create(
			ApiHandlerPipelineStepModel model)
		{
			HandlerPipelineStep record = new HandlerPipelineStep();

			this.Mapper.HandlerPipelineStepMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<HandlerPipelineStep>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.HandlerPipelineStepMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int id,
			ApiHandlerPipelineStepModel model)
		{
			HandlerPipelineStep record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.HandlerPipelineStepMapModelToEF(
					id,
					model,
					record);

				await this.Context.SaveChangesAsync();
			}
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

		protected async Task<List<POCOHandlerPipelineStep>> Where(Expression<Func<HandlerPipelineStep, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOHandlerPipelineStep> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOHandlerPipelineStep>> SearchLinqPOCO(Expression<Func<HandlerPipelineStep, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOHandlerPipelineStep> response = new List<POCOHandlerPipelineStep>();
			List<HandlerPipelineStep> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.HandlerPipelineStepMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<HandlerPipelineStep>> SearchLinqEF(Expression<Func<HandlerPipelineStep, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(HandlerPipelineStep.Id)} ASC";
			}
			return await this.Context.Set<HandlerPipelineStep>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<HandlerPipelineStep>();
		}

		private async Task<List<HandlerPipelineStep>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(HandlerPipelineStep.Id)} ASC";
			}

			return await this.Context.Set<HandlerPipelineStep>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<HandlerPipelineStep>();
		}

		private async Task<HandlerPipelineStep> GetById(int id)
		{
			List<HandlerPipelineStep> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>8c0d604cc7abc91a0f4d34ba09d674b9</Hash>
</Codenesium>*/