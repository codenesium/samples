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
	public abstract class AbstractPipelineStepDestinationRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractPipelineStepDestinationRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOPipelineStepDestination> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOPipelineStepDestination Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOPipelineStepDestination Create(
			PipelineStepDestinationModel model)
		{
			PipelineStepDestination record = new PipelineStepDestination();

			this.Mapper.PipelineStepDestinationMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<PipelineStepDestination>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.PipelineStepDestinationMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			PipelineStepDestinationModel model)
		{
			PipelineStepDestination record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
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
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			PipelineStepDestination record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<PipelineStepDestination>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOPipelineStepDestination> Where(Expression<Func<PipelineStepDestination, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOPipelineStepDestination> SearchLinqPOCO(Expression<Func<PipelineStepDestination, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPipelineStepDestination> response = new List<POCOPipelineStepDestination>();
			List<PipelineStepDestination> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.PipelineStepDestinationMapEFToPOCO(x)));
			return response;
		}

		private List<PipelineStepDestination> SearchLinqEF(Expression<Func<PipelineStepDestination, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PipelineStepDestination.Id)} ASC";
			}
			return this.Context.Set<PipelineStepDestination>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<PipelineStepDestination>();
		}

		private List<PipelineStepDestination> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PipelineStepDestination.Id)} ASC";
			}

			return this.Context.Set<PipelineStepDestination>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<PipelineStepDestination>();
		}
	}
}

/*<Codenesium>
    <Hash>01291e757f94b9adffd641a10ae3b889</Hash>
</Codenesium>*/