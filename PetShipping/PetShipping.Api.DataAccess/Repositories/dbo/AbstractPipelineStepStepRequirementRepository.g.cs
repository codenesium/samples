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
	public abstract class AbstractPipelineStepStepRequirementRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractPipelineStepStepRequirementRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOPipelineStepStepRequirement> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOPipelineStepStepRequirement Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOPipelineStepStepRequirement Create(
			PipelineStepStepRequirementModel model)
		{
			PipelineStepStepRequirement record = new PipelineStepStepRequirement();

			this.Mapper.PipelineStepStepRequirementMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<PipelineStepStepRequirement>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.PipelineStepStepRequirementMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			PipelineStepStepRequirementModel model)
		{
			PipelineStepStepRequirement record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.PipelineStepStepRequirementMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			PipelineStepStepRequirement record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<PipelineStepStepRequirement>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOPipelineStepStepRequirement> Where(Expression<Func<PipelineStepStepRequirement, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOPipelineStepStepRequirement> SearchLinqPOCO(Expression<Func<PipelineStepStepRequirement, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPipelineStepStepRequirement> response = new List<POCOPipelineStepStepRequirement>();
			List<PipelineStepStepRequirement> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.PipelineStepStepRequirementMapEFToPOCO(x)));
			return response;
		}

		private List<PipelineStepStepRequirement> SearchLinqEF(Expression<Func<PipelineStepStepRequirement, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PipelineStepStepRequirement.Id)} ASC";
			}
			return this.Context.Set<PipelineStepStepRequirement>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<PipelineStepStepRequirement>();
		}

		private List<PipelineStepStepRequirement> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PipelineStepStepRequirement.Id)} ASC";
			}

			return this.Context.Set<PipelineStepStepRequirement>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<PipelineStepStepRequirement>();
		}
	}
}

/*<Codenesium>
    <Hash>ca042c44191982d6a987286700cee487</Hash>
</Codenesium>*/