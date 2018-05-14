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
	public abstract class AbstractPipelineStatusRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractPipelineStatusRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOPipelineStatus> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOPipelineStatus Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOPipelineStatus Create(
			PipelineStatusModel model)
		{
			PipelineStatus record = new PipelineStatus();

			this.Mapper.PipelineStatusMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<PipelineStatus>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.PipelineStatusMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			PipelineStatusModel model)
		{
			PipelineStatus record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
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
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			PipelineStatus record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<PipelineStatus>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOPipelineStatus> Where(Expression<Func<PipelineStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOPipelineStatus> SearchLinqPOCO(Expression<Func<PipelineStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPipelineStatus> response = new List<POCOPipelineStatus>();
			List<PipelineStatus> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.PipelineStatusMapEFToPOCO(x)));
			return response;
		}

		private List<PipelineStatus> SearchLinqEF(Expression<Func<PipelineStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PipelineStatus.Id)} ASC";
			}
			return this.Context.Set<PipelineStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<PipelineStatus>();
		}

		private List<PipelineStatus> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PipelineStatus.Id)} ASC";
			}

			return this.Context.Set<PipelineStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<PipelineStatus>();
		}
	}
}

/*<Codenesium>
    <Hash>5ada97c924dd946db3aa3c5ff310a490</Hash>
</Codenesium>*/