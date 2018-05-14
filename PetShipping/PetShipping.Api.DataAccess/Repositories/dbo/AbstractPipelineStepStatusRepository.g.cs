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
	public abstract class AbstractPipelineStepStatusRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractPipelineStepStatusRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOPipelineStepStatus> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOPipelineStepStatus Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOPipelineStepStatus Create(
			ApiPipelineStepStatusModel model)
		{
			PipelineStepStatus record = new PipelineStepStatus();

			this.Mapper.PipelineStepStatusMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<PipelineStepStatus>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.PipelineStepStatusMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			ApiPipelineStepStatusModel model)
		{
			PipelineStepStatus record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
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
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			PipelineStepStatus record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<PipelineStepStatus>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOPipelineStepStatus> Where(Expression<Func<PipelineStepStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOPipelineStepStatus> SearchLinqPOCO(Expression<Func<PipelineStepStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPipelineStepStatus> response = new List<POCOPipelineStepStatus>();
			List<PipelineStepStatus> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.PipelineStepStatusMapEFToPOCO(x)));
			return response;
		}

		private List<PipelineStepStatus> SearchLinqEF(Expression<Func<PipelineStepStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PipelineStepStatus.Id)} ASC";
			}
			return this.Context.Set<PipelineStepStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<PipelineStepStatus>();
		}

		private List<PipelineStepStatus> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PipelineStepStatus.Id)} ASC";
			}

			return this.Context.Set<PipelineStepStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<PipelineStepStatus>();
		}
	}
}

/*<Codenesium>
    <Hash>038c19fe806dfd8e994b21169d27ba3b</Hash>
</Codenesium>*/