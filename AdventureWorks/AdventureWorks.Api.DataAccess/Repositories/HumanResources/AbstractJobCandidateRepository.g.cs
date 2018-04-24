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

		public virtual ApiResponse GetById(int jobCandidateID)
		{
			return this.SearchLinqPOCO(x => x.JobCandidateID == jobCandidateID);
		}

		public virtual POCOJobCandidate GetByIdDirect(int jobCandidateID)
		{
			return this.SearchLinqPOCO(x => x.JobCandidateID == jobCandidateID).JobCandidates.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFJobCandidate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOJobCandidate> GetWhereDirect(Expression<Func<EFJobCandidate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).JobCandidates;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFJobCandidate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFJobCandidate> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.JobCandidateMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFJobCandidate> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.JobCandidateMapEFToPOCO(x, response));
			return response;
		}

		protected virtual List<EFJobCandidate> SearchLinqEF(Expression<Func<EFJobCandidate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFJobCandidate> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>228401cc019931bc2c1e2672c6ac8ce6</Hash>
</Codenesium>*/