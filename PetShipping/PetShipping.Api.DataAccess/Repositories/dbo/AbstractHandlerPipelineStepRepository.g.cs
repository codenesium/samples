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
	public abstract class AbstractHandlerPipelineStepRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractHandlerPipelineStepRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOHandlerPipelineStep> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOHandlerPipelineStep Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOHandlerPipelineStep Create(
			HandlerPipelineStepModel model)
		{
			HandlerPipelineStep record = new HandlerPipelineStep();

			this.Mapper.HandlerPipelineStepMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<HandlerPipelineStep>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.HandlerPipelineStepMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			HandlerPipelineStepModel model)
		{
			HandlerPipelineStep record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
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
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			HandlerPipelineStep record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<HandlerPipelineStep>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOHandlerPipelineStep> Where(Expression<Func<HandlerPipelineStep, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOHandlerPipelineStep> SearchLinqPOCO(Expression<Func<HandlerPipelineStep, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOHandlerPipelineStep> response = new List<POCOHandlerPipelineStep>();
			List<HandlerPipelineStep> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.HandlerPipelineStepMapEFToPOCO(x)));
			return response;
		}

		private List<HandlerPipelineStep> SearchLinqEF(Expression<Func<HandlerPipelineStep, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(HandlerPipelineStep.Id)} ASC";
			}
			return this.Context.Set<HandlerPipelineStep>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<HandlerPipelineStep>();
		}

		private List<HandlerPipelineStep> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(HandlerPipelineStep.Id)} ASC";
			}

			return this.Context.Set<HandlerPipelineStep>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<HandlerPipelineStep>();
		}
	}
}

/*<Codenesium>
    <Hash>dcbe38cd97230cb83c8820c36d898248</Hash>
</Codenesium>*/