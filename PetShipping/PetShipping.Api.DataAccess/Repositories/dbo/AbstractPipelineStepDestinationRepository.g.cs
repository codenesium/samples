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
	public abstract class AbstractPipelineStepDestinationRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractPipelineStepDestinationRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOPipelineStepDestination>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOPipelineStepDestination> Get(int id)
		{
			PipelineStepDestination record = await this.GetById(id);

			return this.Mapper.PipelineStepDestinationMapEFToPOCO(record);
		}

		public async virtual Task<POCOPipelineStepDestination> Create(
			ApiPipelineStepDestinationModel model)
		{
			PipelineStepDestination record = new PipelineStepDestination();

			this.Mapper.PipelineStepDestinationMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<PipelineStepDestination>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.PipelineStepDestinationMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int id,
			ApiPipelineStepDestinationModel model)
		{
			PipelineStepDestination record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.PipelineStepDestinationMapModelToEF(
					id,
					model,
					record);

				await this.Context.SaveChangesAsync();
			}
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

		protected async Task<List<POCOPipelineStepDestination>> Where(Expression<Func<PipelineStepDestination, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPipelineStepDestination> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOPipelineStepDestination>> SearchLinqPOCO(Expression<Func<PipelineStepDestination, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPipelineStepDestination> response = new List<POCOPipelineStepDestination>();
			List<PipelineStepDestination> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.PipelineStepDestinationMapEFToPOCO(x)));
			return response;
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
    <Hash>27f73e0b5f54c300e0a47066d9632b30</Hash>
</Codenesium>*/