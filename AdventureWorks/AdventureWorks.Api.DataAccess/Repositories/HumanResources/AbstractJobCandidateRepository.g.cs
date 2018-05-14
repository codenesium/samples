using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractJobCandidateRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractJobCandidateRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOJobCandidate> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOJobCandidate Get(int jobCandidateID)
		{
			return this.SearchLinqPOCO(x => x.JobCandidateID == jobCandidateID).FirstOrDefault();
		}

		public virtual POCOJobCandidate Create(
			ApiJobCandidateModel model)
		{
			JobCandidate record = new JobCandidate();

			this.Mapper.JobCandidateMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<JobCandidate>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.JobCandidateMapEFToPOCO(record);
		}

		public virtual void Update(
			int jobCandidateID,
			ApiJobCandidateModel model)
		{
			JobCandidate record = this.SearchLinqEF(x => x.JobCandidateID == jobCandidateID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{jobCandidateID}");
			}
			else
			{
				this.Mapper.JobCandidateMapModelToEF(
					jobCandidateID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int jobCandidateID)
		{
			JobCandidate record = this.SearchLinqEF(x => x.JobCandidateID == jobCandidateID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<JobCandidate>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public List<POCOJobCandidate> GetBusinessEntityID(Nullable<int> businessEntityID)
		{
			return this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID);
		}

		protected List<POCOJobCandidate> Where(Expression<Func<JobCandidate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOJobCandidate> SearchLinqPOCO(Expression<Func<JobCandidate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOJobCandidate> response = new List<POCOJobCandidate>();
			List<JobCandidate> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.JobCandidateMapEFToPOCO(x)));
			return response;
		}

		private List<JobCandidate> SearchLinqEF(Expression<Func<JobCandidate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(JobCandidate.JobCandidateID)} ASC";
			}
			return this.Context.Set<JobCandidate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<JobCandidate>();
		}

		private List<JobCandidate> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(JobCandidate.JobCandidateID)} ASC";
			}

			return this.Context.Set<JobCandidate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<JobCandidate>();
		}
	}
}

/*<Codenesium>
    <Hash>df1f1c7dfc7b8e3336eb8374b585ed12</Hash>
</Codenesium>*/