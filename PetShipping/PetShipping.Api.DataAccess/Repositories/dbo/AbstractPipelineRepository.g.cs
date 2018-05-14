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
	public abstract class AbstractPipelineRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractPipelineRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOPipeline> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOPipeline Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOPipeline Create(
			ApiPipelineModel model)
		{
			Pipeline record = new Pipeline();

			this.Mapper.PipelineMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Pipeline>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.PipelineMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			ApiPipelineModel model)
		{
			Pipeline record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
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
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			Pipeline record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Pipeline>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOPipeline> Where(Expression<Func<Pipeline, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOPipeline> SearchLinqPOCO(Expression<Func<Pipeline, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPipeline> response = new List<POCOPipeline>();
			List<Pipeline> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.PipelineMapEFToPOCO(x)));
			return response;
		}

		private List<Pipeline> SearchLinqEF(Expression<Func<Pipeline, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Pipeline.Id)} ASC";
			}
			return this.Context.Set<Pipeline>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Pipeline>();
		}

		private List<Pipeline> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Pipeline.Id)} ASC";
			}

			return this.Context.Set<Pipeline>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Pipeline>();
		}
	}
}

/*<Codenesium>
    <Hash>6635dac2df5a57e11fb57a5278e6bc2b</Hash>
</Codenesium>*/