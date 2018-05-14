using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public abstract class AbstractPipelineStepNoteRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractPipelineStepNoteRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOPipelineStepNote> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOPipelineStepNote Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOPipelineStepNote Create(
			ApiPipelineStepNoteModel model)
		{
			PipelineStepNote record = new PipelineStepNote();

			this.Mapper.PipelineStepNoteMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<PipelineStepNote>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.PipelineStepNoteMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			ApiPipelineStepNoteModel model)
		{
			PipelineStepNote record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
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
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			PipelineStepNote record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<PipelineStepNote>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOPipelineStepNote> Where(Expression<Func<PipelineStepNote, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOPipelineStepNote> SearchLinqPOCO(Expression<Func<PipelineStepNote, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPipelineStepNote> response = new List<POCOPipelineStepNote>();
			List<PipelineStepNote> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.PipelineStepNoteMapEFToPOCO(x)));
			return response;
		}

		private List<PipelineStepNote> SearchLinqEF(Expression<Func<PipelineStepNote, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PipelineStepNote.Id)} ASC";
			}
			return this.Context.Set<PipelineStepNote>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<PipelineStepNote>();
		}

		private List<PipelineStepNote> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PipelineStepNote.Id)} ASC";
			}

			return this.Context.Set<PipelineStepNote>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<PipelineStepNote>();
		}
	}
}

/*<Codenesium>
    <Hash>e746f5971b9ec8777bedbae0e0c7fcb7</Hash>
</Codenesium>*/