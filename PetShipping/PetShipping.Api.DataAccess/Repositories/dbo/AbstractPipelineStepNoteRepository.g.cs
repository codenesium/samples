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
	public abstract class AbstractPipelineStepNoteRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractPipelineStepNoteRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOPipelineStepNote>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOPipelineStepNote> Get(int id)
		{
			PipelineStepNote record = await this.GetById(id);

			return this.Mapper.PipelineStepNoteMapEFToPOCO(record);
		}

		public async virtual Task<POCOPipelineStepNote> Create(
			ApiPipelineStepNoteModel model)
		{
			PipelineStepNote record = new PipelineStepNote();

			this.Mapper.PipelineStepNoteMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<PipelineStepNote>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.PipelineStepNoteMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int id,
			ApiPipelineStepNoteModel model)
		{
			PipelineStepNote record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.PipelineStepNoteMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int id)
		{
			PipelineStepNote record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<PipelineStepNote>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<POCOPipelineStepNote>> Where(Expression<Func<PipelineStepNote, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPipelineStepNote> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOPipelineStepNote>> SearchLinqPOCO(Expression<Func<PipelineStepNote, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPipelineStepNote> response = new List<POCOPipelineStepNote>();
			List<PipelineStepNote> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.PipelineStepNoteMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<PipelineStepNote>> SearchLinqEF(Expression<Func<PipelineStepNote, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PipelineStepNote.Id)} ASC";
			}
			return await this.Context.Set<PipelineStepNote>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<PipelineStepNote>();
		}

		private async Task<List<PipelineStepNote>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PipelineStepNote.Id)} ASC";
			}

			return await this.Context.Set<PipelineStepNote>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<PipelineStepNote>();
		}

		private async Task<PipelineStepNote> GetById(int id)
		{
			List<PipelineStepNote> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>33f48ae87d0e32be2a3d6dad6e9d7aee</Hash>
</Codenesium>*/