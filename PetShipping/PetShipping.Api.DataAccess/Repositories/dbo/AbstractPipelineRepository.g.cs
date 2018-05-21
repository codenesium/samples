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
	public abstract class AbstractPipelineRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractPipelineRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOPipeline>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOPipeline> Get(int id)
		{
			Pipeline record = await this.GetById(id);

			return this.Mapper.PipelineMapEFToPOCO(record);
		}

		public async virtual Task<POCOPipeline> Create(
			ApiPipelineModel model)
		{
			Pipeline record = new Pipeline();

			this.Mapper.PipelineMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Pipeline>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.PipelineMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int id,
			ApiPipelineModel model)
		{
			Pipeline record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.PipelineMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int id)
		{
			Pipeline record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Pipeline>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<POCOPipeline>> Where(Expression<Func<Pipeline, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPipeline> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOPipeline>> SearchLinqPOCO(Expression<Func<Pipeline, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPipeline> response = new List<POCOPipeline>();
			List<Pipeline> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.PipelineMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<Pipeline>> SearchLinqEF(Expression<Func<Pipeline, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Pipeline.Id)} ASC";
			}
			return await this.Context.Set<Pipeline>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Pipeline>();
		}

		private async Task<List<Pipeline>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Pipeline.Id)} ASC";
			}

			return await this.Context.Set<Pipeline>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Pipeline>();
		}

		private async Task<Pipeline> GetById(int id)
		{
			List<Pipeline> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>9ff5a760d1cc23ca2f4044e31c063f8a</Hash>
</Codenesium>*/