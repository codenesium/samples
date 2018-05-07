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

		public virtual int Create(
			JobCandidateModel model)
		{
			EFJobCandidate record = new EFJobCandidate();

			this.Mapper.JobCandidateMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFJobCandidate>().Add(record);
			this.Context.SaveChanges();
			return record.JobCandidateID;
		}

		public virtual void Update(
			int jobCandidateID,
			JobCandidateModel model)
		{
			EFJobCandidate record = this.SearchLinqEF(x => x.JobCandidateID == jobCandidateID).FirstOrDefault();
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
			EFJobCandidate record = this.SearchLinqEF(x => x.JobCandidateID == jobCandidateID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFJobCandidate>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual POCOJobCandidate Get(int jobCandidateID)
		{
			return this.SearchLinqPOCO(x => x.JobCandidateID == jobCandidateID).FirstOrDefault();
		}

		public virtual List<POCOJobCandidate> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		private List<POCOJobCandidate> Where(Expression<Func<EFJobCandidate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOJobCandidate> SearchLinqPOCO(Expression<Func<EFJobCandidate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOJobCandidate> response = new List<POCOJobCandidate>();
			List<EFJobCandidate> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.JobCandidateMapEFToPOCO(x)));
			return response;
		}

		private List<EFJobCandidate> SearchLinqEF(Expression<Func<EFJobCandidate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFJobCandidate>().Where(predicate).AsQueryable().OrderBy("JobCandidateID ASC").Skip(skip).Take(take).ToList<EFJobCandidate>();
			}
			else
			{
				return this.Context.Set<EFJobCandidate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFJobCandidate>();
			}
		}

		private List<EFJobCandidate> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFJobCandidate>().Where(predicate).AsQueryable().OrderBy("JobCandidateID ASC").Skip(skip).Take(take).ToList<EFJobCandidate>();
			}
			else
			{
				return this.Context.Set<EFJobCandidate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFJobCandidate>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>dbfe5c347bc7f00f234c946da629971a</Hash>
</Codenesium>*/