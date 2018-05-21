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
	public abstract class AbstractPipelineStatusRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractPipelineStatusRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOPipelineStatus>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOPipelineStatus> Get(int id)
		{
			PipelineStatus record = await this.GetById(id);

			return this.Mapper.PipelineStatusMapEFToPOCO(record);
		}

		public async virtual Task<POCOPipelineStatus> Create(
			ApiPipelineStatusModel model)
		{
			PipelineStatus record = new PipelineStatus();

			this.Mapper.PipelineStatusMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<PipelineStatus>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.PipelineStatusMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int id,
			ApiPipelineStatusModel model)
		{
			PipelineStatus record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.PipelineStatusMapModelToEF(
					id,
					model,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int id)
		{
			PipelineStatus record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<PipelineStatus>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<POCOPipelineStatus>> Where(Expression<Func<PipelineStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPipelineStatus> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOPipelineStatus>> SearchLinqPOCO(Expression<Func<PipelineStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPipelineStatus> response = new List<POCOPipelineStatus>();
			List<PipelineStatus> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.PipelineStatusMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<PipelineStatus>> SearchLinqEF(Expression<Func<PipelineStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PipelineStatus.Id)} ASC";
			}
			return await this.Context.Set<PipelineStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<PipelineStatus>();
		}

		private async Task<List<PipelineStatus>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PipelineStatus.Id)} ASC";
			}

			return await this.Context.Set<PipelineStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<PipelineStatus>();
		}

		private async Task<PipelineStatus> GetById(int id)
		{
			List<PipelineStatus> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>b10862d409e6f89641dc25459b104d79</Hash>
</Codenesium>*/