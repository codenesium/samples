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
	public abstract class AbstractPipelineStepStatusRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractPipelineStepStatusRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOPipelineStepStatus>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOPipelineStepStatus> Get(int id)
		{
			PipelineStepStatus record = await this.GetById(id);

			return this.Mapper.PipelineStepStatusMapEFToPOCO(record);
		}

		public async virtual Task<POCOPipelineStepStatus> Create(
			ApiPipelineStepStatusModel model)
		{
			PipelineStepStatus record = new PipelineStepStatus();

			this.Mapper.PipelineStepStatusMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<PipelineStepStatus>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.PipelineStepStatusMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int id,
			ApiPipelineStepStatusModel model)
		{
			PipelineStepStatus record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.PipelineStepStatusMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int id)
		{
			PipelineStepStatus record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<PipelineStepStatus>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<POCOPipelineStepStatus>> Where(Expression<Func<PipelineStepStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPipelineStepStatus> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOPipelineStepStatus>> SearchLinqPOCO(Expression<Func<PipelineStepStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPipelineStepStatus> response = new List<POCOPipelineStepStatus>();
			List<PipelineStepStatus> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.PipelineStepStatusMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<PipelineStepStatus>> SearchLinqEF(Expression<Func<PipelineStepStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PipelineStepStatus.Id)} ASC";
			}
			return await this.Context.Set<PipelineStepStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<PipelineStepStatus>();
		}

		private async Task<List<PipelineStepStatus>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PipelineStepStatus.Id)} ASC";
			}

			return await this.Context.Set<PipelineStepStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<PipelineStepStatus>();
		}

		private async Task<PipelineStepStatus> GetById(int id)
		{
			List<PipelineStepStatus> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>2a0b979607330cd6f3251d1900fc277a</Hash>
</Codenesium>*/