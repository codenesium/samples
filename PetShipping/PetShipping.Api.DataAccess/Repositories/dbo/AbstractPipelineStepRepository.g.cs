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
	public abstract class AbstractPipelineStepRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractPipelineStepRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOPipelineStep> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOPipelineStep Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOPipelineStep Create(
			PipelineStepModel model)
		{
			PipelineStep record = new PipelineStep();

			this.Mapper.PipelineStepMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<PipelineStep>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.PipelineStepMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			PipelineStepModel model)
		{
			PipelineStep record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
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
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			PipelineStep record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<PipelineStep>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOPipelineStep> Where(Expression<Func<PipelineStep, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOPipelineStep> SearchLinqPOCO(Expression<Func<PipelineStep, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPipelineStep> response = new List<POCOPipelineStep>();
			List<PipelineStep> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.PipelineStepMapEFToPOCO(x)));
			return response;
		}

		private List<PipelineStep> SearchLinqEF(Expression<Func<PipelineStep, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PipelineStep.Id)} ASC";
			}
			return this.Context.Set<PipelineStep>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<PipelineStep>();
		}

		private List<PipelineStep> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PipelineStep.Id)} ASC";
			}

			return this.Context.Set<PipelineStep>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<PipelineStep>();
		}
	}
}

/*<Codenesium>
    <Hash>80d993f94c8792082b4d2b6e9d49a2e6</Hash>
</Codenesium>*/