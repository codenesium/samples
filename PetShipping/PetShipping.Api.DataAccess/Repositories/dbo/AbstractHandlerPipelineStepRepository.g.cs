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
		protected IDALHandlerPipelineStepMapper Mapper { get; }

		public AbstractHandlerPipelineStepRepository(
			IDALHandlerPipelineStepMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOHandlerPipelineStep>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOHandlerPipelineStep> Get(int id)
		{
			HandlerPipelineStep record = await this.GetById(id);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOHandlerPipelineStep> Create(
			DTOHandlerPipelineStep dto)
		{
			HandlerPipelineStep record = new HandlerPipelineStep();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<HandlerPipelineStep>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int id,
			DTOHandlerPipelineStep dto)
		{
			HandlerPipelineStep record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					id,
					dto,
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

		protected async Task<List<DTOHandlerPipelineStep>> Where(Expression<Func<HandlerPipelineStep, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOHandlerPipelineStep> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOHandlerPipelineStep>> SearchLinqDTO(Expression<Func<HandlerPipelineStep, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOHandlerPipelineStep> response = new List<DTOHandlerPipelineStep>();
			List<HandlerPipelineStep> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
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
    <Hash>5719f116cfaaf49ecd6045bda189e22b</Hash>
</Codenesium>*/